using AutoMapper;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class CommissionsAndFeesService : ICommissionsAndFeesService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;

        public CommissionsAndFeesService(SqlDataAccess sqlDataAccess, IMapper mapper, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _mapper = mapper;
            _commonService = commonService;
        }

        public async Task<dynamic> GetCommissionsAndFeesReport(CommissionsAndFeesRequest requests)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            requests.Month = (requests.Month == null) ? maxDateInDb.Month : requests.Month;
            requests.Year = (requests.Year == null) ? maxDateInDb.Year : requests.Year;

            var spName = StoredProcedureNames.CommissionsAndFees;
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

        public async Task<dynamic> GetCommissionsAndFeesReportAccounts(CommissionsAndFeesAccounts requests)
        {
            var maxMonthYear = await _commonService.GetMonthAndYearAsync(null, null);
            if (requests.Month == null || requests.Year == null)
            {
                requests.Month = maxMonthYear.Month;
                requests.Year = maxMonthYear.Year;
            }

            var spName = StoredProcedureNames.CommissionsAndFeesAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pBranch = @BranchCode ," +
                $"@pGlSub = @GLSubHeadCode ," +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, requests);
        }
    }
}
