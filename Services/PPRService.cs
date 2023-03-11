using System.Threading.Tasks;
using WemaAnalyticsAPI.Common;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class PPRService : IPPRService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly ICommonService _commonService;

        public PPRService(SqlDataAccess sqlDataAccess, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _commonService = commonService;
        }


        public async Task<dynamic> GetPPRReport(GetPPRRequest PPRRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            PPRRequest.Month = (PPRRequest.Month == null) ? maxDateInDb.Month : PPRRequest.Month;
            PPRRequest.Year = (PPRRequest.Year == null) ? maxDateInDb.Year : PPRRequest.Year;
            var defaultPPRGLSubHeadCode = PPRRequest.GLSubHeadCode == null ? 
                Utility.AppConfiguration().GetSection("DefaultPPRGLSubHead").Value : PPRRequest.GLSubHeadCode;

            var spName = StoredProcedureNames.PPR;

            //string sql = $"exec [dbo].[{spName}]" +
            //    $"@pDirectorateCode = @DirectorateCode ," +
            //    $"@pRegionCode = @RegionCode," +
            //    $"@pZoneCode = @ZoneCode," +
            //    $"@pBranchCode = @BranchCode," +
            //    $"@pSBU = @SbuCode," +
            //    $"@pAccountOfficer = @AccountOfficerCode," +
            //    $"@pStaffID = @StaffId," +
            //    $"@pMonth = @Month," +
            //    $"@pYear = @Year";

            string sql = $"exec [dbo].[{spName}]" +
                $"@pGLSubHead = @GLSubHeadCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, PPRRequest);
        }

    }
}
