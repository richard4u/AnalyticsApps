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
    public class LoanService : ILoan
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;

        public LoanService(IServiceProvider provider, SqlDataAccess sqlDataAccess, IMapper mapper, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _mapper = mapper;
            _commonService = commonService;
        }

        public async Task<dynamic> GetLoanReports(GetReportRequest loanRequest)
        {
            var loanReportRequest = _mapper.Map<ReportStructure>(loanRequest);

            if (loanReportRequest.ReportDate == null)
            {
                loanReportRequest.ReportDate = await _commonService.GetMaxDate();
            }

            var spName = StoredProcedureNames.LoansByCluster;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@pRunDate = @ReportDate";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, loanReportRequest);
        }

        public async Task<dynamic> GetLoanAccounts(AccountRequest accountRequest)
        {
            var accountLoanReportRequest = _mapper.Map<AccountReport>(accountRequest);

            if (accountLoanReportRequest.ReportDate == null)
            {
                accountLoanReportRequest.ReportDate = await _commonService.GetMaxDate();
            }
            var spName = StoredProcedureNames.LoansByClusterAccounts;
            string sql = $"exec  [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pRunDate = @ReportDate";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, accountLoanReportRequest);
        }

        public async Task<dynamic> GetAlcoLoanReports(GetAlcoRequest alcoLoanRequest)
        {
            var alcoLoanReport = _mapper.Map<AlcoReport>(alcoLoanRequest);

            if (alcoLoanReport.DateFrom == null && alcoLoanReport.DateTo == null)
            {
                var maxDate =  await _commonService.GetMaxDate();
                alcoLoanReport.DateFrom = maxDate;
                alcoLoanReport.DateTo = maxDate;
            }

            var spName = StoredProcedureNames.AlcoLoansByCluster;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pSBU = @SbuCode," +
                $"@pAccountOfficer = @AccountOfficerCode," +
                $"@pStaffID = @StaffId," +
                $"@p_date_from = @DateFrom," +
                $"@p_date_to = @DateTo";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, alcoLoanReport);
        }

        public async Task<dynamic> GetAlcoLoanAccounts(GetAlcoAccountRequest accountRequest)
        {
            var alcoLoanAccountReport = _mapper.Map<AlcoAccountReport>(accountRequest);

            if (alcoLoanAccountReport.ReportDate == null)
            {
                alcoLoanAccountReport.ReportDate = await _commonService.GetMaxDate();
            }

            var spName = StoredProcedureNames.AlcoLoansByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pType = @Type," +
                $"@pRunDate = @ReportDate";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, alcoLoanAccountReport);
        }

        public async Task<dynamic> GetNewLoanSalesReport(MonthlyReportRequest request)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            request.Month = (request.Month == null) ? maxDateInDb.Month : request.Month;
            request.Year = (request.Year == null) ? maxDateInDb.Year : request.Year;

            var spName = StoredProcedureNames.NewLoansSalesByCluster;
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

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, request);
        }

        public async Task<dynamic> GetNewLoanSalesReportAccounts(MonthlyReportAccountsRequest request)
        {
            var maxDateInDb = await _commonService.GetMaxDate();
            request.Month = (request.Month == null) ? maxDateInDb.Month : request.Month;
            request.Year = (request.Year == null) ? maxDateInDb.Year : request.Year;

            var spName = StoredProcedureNames.NewLoansSalesByClusterAccounts;
            string sql = $"exec [dbo].[{spName}]" +
                $"@pAccountOfficer = @AccountOfficerCode ," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, request);
        }
    }
    
}
