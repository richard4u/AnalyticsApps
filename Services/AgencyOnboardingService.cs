using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class AgencyOnboardingService : IAgencyOnboardingService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly ICommonService _commonService;

        public AgencyOnboardingService(SqlDataAccess sqlDataAccess, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _commonService = commonService;
        }

        public async Task<dynamic> GetAgencyOnboardingByCluster(AgencyOnboardingRequest agencyOnboardingRequest)
        {
            var maxMonthYear = await _commonService.GetMonthAndYearAsync(null, null);
            if (agencyOnboardingRequest.Month == null || agencyOnboardingRequest.Year == null)
            {
                agencyOnboardingRequest.Month = maxMonthYear.Month;
                agencyOnboardingRequest.Year = maxMonthYear.Year;
            }
            var spName = StoredProcedureNames.AgentOnBoardingByCluster;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, agencyOnboardingRequest);
        }

        public async Task<dynamic> GetAgencyOnboardingAgents(AgencyOnboardingAgencyRequest agencyRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate();
            agencyRequest.Month = (agencyRequest.Month == null) ? maxDateInDb.Month : agencyRequest.Month;
            agencyRequest.Year = (agencyRequest.Year == null) ? maxDateInDb.Year : agencyRequest.Year;

            //sp_agency_onboarding_agents
            var spName = StoredProcedureNames.AgentOnBoardingByClusterAgents;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, agencyRequest);
        }
    }
}
