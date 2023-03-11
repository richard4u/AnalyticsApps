using AutoMapper;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Common;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class APRService : IAPRService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly ICommonService _commonService;

        public APRService(SqlDataAccess sqlDataAccess, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _commonService = commonService;
        }

        public async Task<dynamic> GetAPRFilters()
        {
            return await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.APRFilters);
        }

        public async Task<dynamic> GetAPRReport(GetAPRRequest aPRRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            aPRRequest.Month = (aPRRequest.Month == null) ? maxDateInDb.Month : aPRRequest.Month;
            aPRRequest.Year = (aPRRequest.Year == null) ? maxDateInDb.Year : aPRRequest.Year;

            if (aPRRequest.Filter == null)
            {
                aPRRequest.Filter = Utility.AppConfiguration().GetSection("DefaultAPRFilter").Value;
            }

            var spName = aPRRequest.FilterType == APRFilterType.BottomFilter ?  
                StoredProcedureNames.APRBottom : StoredProcedureNames.APRTop;

            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pZoneCode = @ZoneCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year," +
                $"@rank = @Filter," +
                $"@sort = @Limit";
                
            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, aPRRequest);
        }
    
        public async Task<dynamic> GetAPRReport (GetAPRReqestQuery requestQuery)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            requestQuery.Month = (requestQuery.Month == null) ? maxDateInDb.Month : requestQuery.Month;
            requestQuery.Year = (requestQuery.Year == null) ? maxDateInDb.Year : requestQuery.Year;

            var spName = StoredProcedureNames.APRSearchQuery;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pZoneCode = @ZoneCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year," +
                $"@pAccount = @AccountQuery";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, requestQuery);
        }
    
    }
}
