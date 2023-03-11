using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
  public partial class MPRReportService : IMPRReport
  {
    private readonly SqlDataAccess _sqlDataAccess;
    private readonly ICommonService _commonService;

    public MPRReportService(SqlDataAccess sqlDataAccess, IMapper mapper, ICommonService commonService)
    {
      _sqlDataAccess = sqlDataAccess;
      _commonService = commonService;
    }

    private string GetAssetsOrLiabilitiesQuery(string spName) => $"exec [dbo].[{spName}]" +
            $"@pDirectorateCode = @DirectorateCode ," +
            $"@pRegionCode = @RegionCode," +
            $"@pZoneCode = @ZoneCode," +
            $"@pBranchCode = @BranchCode," +
            $"@pSBU = @SbuCode," +
            $"@pAccountOfficer = @AccountOfficerCode," +
            $"@pStaffID = @StaffId," +
            $"@pMonth = @Month," +
            $"@pYear = @Year";


    private object GetFormatedCCYData(dynamic data)
    {

      if (data is null) return null;

      var currencyDataObject = new Dictionary<string, List<object>>();

      // pull out currency from data
      foreach (var rows in data)
      {
        var fields = rows as IDictionary<string, object>;
        var currency = (string)fields["CURRENCY"];

        if (currency is null) continue;

        if (!currencyDataObject.ContainsKey(currency))
        {
          currencyDataObject.Add((string)fields["CURRENCY"], new List<object> { fields });
          continue;
        }

        // populate key 
        var valuesInDictionary = currencyDataObject[currency];
        valuesInDictionary.Add(fields);

        currencyDataObject[currency] = valuesInDictionary;
      }

      return currencyDataObject;
    }
    public async Task<dynamic> GetMPRBalanceSheetReport(GetMPRReport requests)
    {
      var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
                                                            //var maxDateInDb = new DateTime(2021, 11, 30);  // query db for maxDate eg 2021-06-30
      requests.Month = (requests.Month == null) ? maxDateInDb.Month : requests.Month;
      requests.Year = (requests.Year == null) ? maxDateInDb.Year : requests.Year;

      var spNameAssets = StoredProcedureNames.MPRBalanceSheetTotalAssets;
      var spNameLiabilities = StoredProcedureNames.MPRBalanceSheetTotalLiabilities;

      if (requests.BalanceSheetType.Equals(BalanceSheetType.CCY))
      {
        spNameAssets = StoredProcedureNames.MPRBalanceSheetCCYAssets;
        spNameLiabilities = StoredProcedureNames.MPRBalanceSheetCCYLiabilities;

        string ccyAssetsQuery = GetAssetsOrLiabilitiesQuery(spNameAssets);
        string ccyLiabilitiesQuery = GetAssetsOrLiabilitiesQuery(spNameLiabilities);

        //var convertedRes = JsonConvert.DeserializeObject<MPRCurrency>(assetsRes);

        return new
        {
          Assets = GetFormatedCCYData(await _sqlDataAccess.LoadQueryData<dynamic>(ccyAssetsQuery, requests)),
          Liabilities = GetFormatedCCYData(await _sqlDataAccess.LoadQueryData<dynamic>(ccyLiabilitiesQuery, requests))
        };

      }

      var totalAssetsQuery = GetAssetsOrLiabilitiesQuery(spNameAssets);
      var totalLiabilitiesQuery = GetAssetsOrLiabilitiesQuery(spNameLiabilities);

      IEnumerable<dynamic> totalAssetsData = (await _sqlDataAccess.LoadQueryData<dynamic>(totalAssetsQuery, requests));
      var totalLiabilitiesData = await _sqlDataAccess.LoadQueryData<dynamic>(totalLiabilitiesQuery, requests);

      return new
      {
        Assets = totalAssetsData,
        Liabilities = totalLiabilitiesData
      };
    }

    public async Task<dynamic> GetHeadOfficeExpenseReports(GetHeadOfficeExpenseRequest request)
    {
      var maxDateInDb = await _commonService.GetMaxDate();
      request.Month = (request.Month == null) ? maxDateInDb.Month : request.Month;
      request.Year = (request.Year == null) ? maxDateInDb.Year : request.Year;

      var spName = request.Captions == null ? StoredProcedureNames.HeadOfficeExpense : StoredProcedureNames.HeadOfficeExpenseAccounts;

      if (request.Captions != null && request.DepartmentCode == "ALL")
      {
        throw new Exception("Department Code is required for Accounts");
      }

      string sql = $"exec [dbo].[{spName}]" +
          $"@pDepartmentCode = @DepartmentCode," +
          (request.Captions != null ? $"@pCaption = @Captions," : "") +
          $"@pStaffID = @StaffId," +
          $"@pMonth = @Month," +
          $"@pYear = @Year";

      return await _sqlDataAccess.LoadQueryData<dynamic>(sql, request);
    }

    public async Task<dynamic> GetMPRIncomeStatementReport(GetMPRIncomeReport requests)
    {
      var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
      requests.Month = (requests.Month == null) ? maxDateInDb.Month : requests.Month;
      requests.Year = (requests.Year == null) ? maxDateInDb.Year : requests.Year;

      var spName = requests.Caption is null ? StoredProcedureNames.MPRIncomeStatement : StoredProcedureNames.MPRIncomeStatementCaptions;

      string sql = $"exec [dbo].[{spName}]" +
          $"@pDirectorateCode = @DirectorateCode ," +
          $"@pRegionCode = @RegionCode," +
          $"@pZoneCode = @ZoneCode," +
          $"@pBranchCode = @BranchCode," +
          $"@pSBU = @SbuCode," +
          (requests.Caption != null ? $"@pCaption = @Caption," : "") +
          $"@pAccountOfficer = @AccountOfficerCode," +
          $"@pStaffID = @StaffId," +
          $"@pMonth = @Month," +
          $"@pYear = @Year";

      return await _sqlDataAccess.LoadQueryData<dynamic>(sql, requests);
    }

    public async Task<dynamic> GetMPRLandingViewData(GetMPRLandingViewReport requests)
    {
      var maxDateInDb = await _commonService.GetMaxDate();
      requests.Month = (requests.Month == null) ? maxDateInDb.Month : requests.Month;
      requests.Year = (requests.Year == null) ? maxDateInDb.Year : requests.Year;

      var spName = StoredProcedureNames.MPRLandingViewData;
      string sql = $"exec [dbo].[{spName}]" +
          $"@pDirectorateCode = @DirectorateCode ," +
          $"@pRegionCode = @RegionCode," +
          $"@pZoneCode = @ZoneCode," +
          $"@pBranchCode = @BranchCode," +
          $"@pSBU = @SbuCode," +
          $"@pAccountOfficer = @AccountOfficerCode," +
          $"@pStaffID = @StaffId," +
          $"@pMonth = @Month," +
          $"@pYear = @Year";

      return await _sqlDataAccess.LoadQueryData<dynamic>(sql, requests);
    }

    public async Task<dynamic> GetMPRBalanceSheetReportTest(GetMPRReport requests)
    {
      var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
                                                            //var maxDateInDb = new DateTime(2021, 11, 30);  // query db for maxDate eg 2021-06-30
      requests.Month = (requests.Month == null) ? maxDateInDb.Month : requests.Month;
      requests.Year = (requests.Year == null) ? maxDateInDb.Year : requests.Year;

      var spNameAssets = StoredProcedureNames.MPRBalanceSheetTotalAssets;
      var spNameLiabilities = StoredProcedureNames.MPRBalanceSheetTotalLiabilities;

      if (requests.BalanceSheetType.Equals(BalanceSheetType.CCY))
      {
        spNameAssets = StoredProcedureNames.MPRBalanceSheetCCYAssets;
        spNameLiabilities = StoredProcedureNames.MPRBalanceSheetCCYLiabilities;

        string ccyAssetsQuery = GetAssetsOrLiabilitiesQuery(spNameAssets);
        string ccyLiabilitiesQuery = GetAssetsOrLiabilitiesQuery(spNameLiabilities);

        return new
        {
          Assets = await _sqlDataAccess.LoadQueryData<dynamic>(ccyAssetsQuery, requests),
          Liabilities = await _sqlDataAccess.LoadQueryData<dynamic>(ccyLiabilitiesQuery, requests)
        };
      }

      var totalAssetsQuery = GetAssetsOrLiabilitiesQuery(spNameAssets);
      var totalLiabilitiesQuery = GetAssetsOrLiabilitiesQuery(spNameLiabilities);

      IEnumerable<dynamic> totalAssetsData = (await _sqlDataAccess.LoadQueryData<dynamic>(totalAssetsQuery, requests));
      var totalLiabilitiesData = await _sqlDataAccess.LoadQueryData<dynamic>(totalLiabilitiesQuery, requests);

      return new
      {
        Assets = totalAssetsData,
        Liabilities = totalLiabilitiesData
      };

    }

    public async Task<dynamic> GetMPRIncomeStatementAccount(GetMPRIncomeStatementAccount request)
    {
      var maxDateInDb = await _commonService.GetMaxDate();
      request.Month = (request.Month == null) ? maxDateInDb.Month : request.Month;
      request.Year = (request.Year == null) ? maxDateInDb.Year : request.Year;

      var spName = StoredProcedureNames.MPRIncomeStatementAccounts;

      string sql = $"exec [dbo].[{spName}]" +
          $"@pCaption = @Caption," +
          $"@pStaffID = @StaffId," +
          $"@pMonth = @Month," +
          $"@pYear = @Year";

      return await _sqlDataAccess.LoadQueryData<dynamic>(sql, request);
    }
  }
}
