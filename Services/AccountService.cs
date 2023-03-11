using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;

        public AccountService(SqlDataAccess sqlDataAccess, IMapper mapper, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _mapper = mapper;
            _commonService = commonService;
        }

        public async Task<dynamic> GetAccountsStatusAccountReports(GetAccountStatusAccountRequest accountRequest)
        {
            var accountStatusAccount = _mapper.Map<AccountStatusAccount>(accountRequest);

            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            accountStatusAccount.Month = (accountStatusAccount.Month == null) ? maxDateInDb.Month : accountStatusAccount.Month;
            accountStatusAccount.Year = (accountStatusAccount.Year == null) ? maxDateInDb.Year : accountStatusAccount.Year;

            var spName = StoredProcedureNames.AccountStatusByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@p_type = @Type," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, accountStatusAccount);
        }

        public async Task<dynamic> GetAccountsStatusReports(GetAccountStatusRequest accountStatusRequest)
        {
            var accountStatus = _mapper.Map<AccountStatus>(accountStatusRequest);

            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            accountStatus.Month = (accountStatus.Month == null) ? maxDateInDb.Month : accountStatus.Month;
            accountStatus.Year = (accountStatus.Year == null) ? maxDateInDb.Year : accountStatus.Year;

            var spName = StoredProcedureNames.AccountStatusByCluster;
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

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, accountStatus);
        }

        public async Task<dynamic> GetMTDAccountActivity(MonthlyReportRequest mtdAccountActivity)
        {
            var maxMonthYear = await _commonService.GetMonthAndYearAsync(null, null);
            if (mtdAccountActivity.Month == null || mtdAccountActivity.Year == null)
            {
                mtdAccountActivity.Month = maxMonthYear.Month;
                mtdAccountActivity.Year = maxMonthYear.Year;
            }

            var spName = StoredProcedureNames.MTDAccountActivityByCluster;
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

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, mtdAccountActivity);
        }

        public async Task<dynamic> GetMTDAccountActivityAccount(GetAccountStatusAccountRequest mtdAccountActivityAccount)
        {
            var mtdActivityAccount = _mapper.Map<AccountStatusAccount>(mtdAccountActivityAccount);
            var maxMonthYear = await _commonService.GetMonthAndYearAsync(null, null);
            if (mtdActivityAccount.Month == null || mtdActivityAccount.Year == null)
            {
                mtdActivityAccount.Month = maxMonthYear.Month;
                mtdActivityAccount.Year = maxMonthYear.Year;
            }
         
            var spName = StoredProcedureNames.MTDAccountActivityByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@p_type = @Type," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, mtdActivityAccount);
        }

        public async Task<dynamic> GetYTDAccountActivity(MonthlyReportRequest ytdAccountActivity)
        {
            var maxDateInDb = await _commonService.GetMaxDate();
            ytdAccountActivity.Month = (ytdAccountActivity.Month == null) ? maxDateInDb.Month : ytdAccountActivity.Month;
            ytdAccountActivity.Year = (ytdAccountActivity.Year == null) ? maxDateInDb.Year : ytdAccountActivity.Year;

            var spName = StoredProcedureNames.YTDAccountActivityByCluster;
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

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, ytdAccountActivity);
        }

        public async Task<dynamic> GetYTDAccountActivityAccounts(GetAccountStatusAccountRequest ytdAccountActivityAccount)
        {
            var mtdActivityAccount = _mapper.Map<AccountStatusAccount>(ytdAccountActivityAccount);

            var maxDateInDb = await _commonService.GetMaxDate();
            mtdActivityAccount.Month = (mtdActivityAccount.Month == null) ? maxDateInDb.Month : mtdActivityAccount.Month;
            mtdActivityAccount.Year = (mtdActivityAccount.Year == null) ? maxDateInDb.Year : mtdActivityAccount.Year;

            var spName = StoredProcedureNames.YTDAccountActivityByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@p_type = @Type," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, mtdActivityAccount);
        }


        public async Task<dynamic> GetNewToBankAlatAccount(NTBAccountRequest ntbAccountRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate();
            ntbAccountRequest.Month = (ntbAccountRequest.Month == null) ? maxDateInDb.Month : ntbAccountRequest.Month;
            ntbAccountRequest.Year = (ntbAccountRequest.Year == null) ? maxDateInDb.Year : ntbAccountRequest.Year;

            var spName = StoredProcedureNames.NewToBankAlatByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, ntbAccountRequest);
        }


        public async Task<dynamic> GetNewToBankAlatReport(GetAccountStatusRequest newToBankRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            newToBankRequest.Month = (newToBankRequest.Month == null) ? maxDateInDb.Month : newToBankRequest.Month;
            newToBankRequest.Year = (newToBankRequest.Year == null) ? maxDateInDb.Year : newToBankRequest.Year;

            var spName = StoredProcedureNames.NewToBankAlatByCluster;
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

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, newToBankRequest);
        }
    }



}