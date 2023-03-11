using AutoMapper;
using System;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.DataAccess;
using WemaAnalyticsAPI.Domain;

namespace WemaAnalyticsAPI.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly ICommonService _commonService;

        public ExpenseService(SqlDataAccess sqlDataAccess, ICommonService commonService)
        {
            _sqlDataAccess = sqlDataAccess;
            _commonService = commonService;
        }

        public async Task<dynamic> GetBranchesExpenseReports(GetExpenseRequest branchesExpenseRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            branchesExpenseRequest.Month = (branchesExpenseRequest.Month == null) ? maxDateInDb.Month : branchesExpenseRequest.Month;
            branchesExpenseRequest.Year = (branchesExpenseRequest.Year == null) ? maxDateInDb.Year : branchesExpenseRequest.Year;

            if (branchesExpenseRequest.BranchCode.ToLower() != "all" && branchesExpenseRequest.Caption.ToLower() != "all")
            {
                return await _sqlDataAccess.SPLoadData<dynamic>(StoredProcedureNames.BranchesExpenseAccounts, new { 
                    pBranch = branchesExpenseRequest.BranchCode, 
                    pCaption = branchesExpenseRequest.Caption, 
                    pStaffID = branchesExpenseRequest.StaffId, 
                    pMonth = branchesExpenseRequest.Month, 
                    pYear = branchesExpenseRequest.Year });
            }

            var spName = branchesExpenseRequest.Type.ToLower() == "ytd" ? 
                StoredProcedureNames.BranchesExpenseYTD : 
                StoredProcedureNames.BranchesExpenseMTD;

            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pZoneCode = @ZoneCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";
                    
            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, branchesExpenseRequest);
        }

        public async Task<dynamic> GetBranchesExpenseTransactionsReports(GetExpenseTransactions branchesExpenseTransactions)
        {
            var maxDateInDb = await _commonService.GetMaxDate();  // query db for maxDate eg 2021-06-30
            branchesExpenseTransactions.Month = (branchesExpenseTransactions.Month == null) ? maxDateInDb.Month : branchesExpenseTransactions.Month;
            branchesExpenseTransactions.Year = (branchesExpenseTransactions.Year == null) ? maxDateInDb.Year : branchesExpenseTransactions.Year;

            // should be cleaned up
            var spName = branchesExpenseTransactions.Type.ToLower() == "ytd" ?
                StoredProcedureNames.BranchesExpenseTransactionsYTD :
                StoredProcedureNames.BranchesExpenseTransactionsMTD;

            string sql = $"exec [dbo].[{spName}]" +
                $"@pBranch = @BranchCode," +
                $"@pGlSub = @GLSubHeadCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, branchesExpenseTransactions);
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

        public async Task<dynamic> GetHeadOfficeExpenseTransactionsReports(GetHeadOfficeTransactions request)
        {
            var maxDateInDb = await _commonService.GetMaxDate();
            request.Month = (request.Month == null) ? maxDateInDb.Month : request.Month;
            request.Year = (request.Year == null) ? maxDateInDb.Year : request.Year;

            var spName = StoredProcedureNames.HeadOfficeExpenseTransactions;

            string sql = $"exec [dbo].[{spName}]" +
                $"@pDepartmentCode = @DepartmentCode," +
                $"@pGlSub = @GLCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, request);
        }

        public async Task<dynamic> GetRetailExpenseReports(GetRetailExpenseRequest retailExpenseRequest)
        {
            var maxDateInDb = await _commonService.GetMaxDate(); 
            retailExpenseRequest.Month = (retailExpenseRequest.Month == null) ? maxDateInDb.Month : retailExpenseRequest.Month;
            retailExpenseRequest.Year = (retailExpenseRequest.Year == null) ? maxDateInDb.Year : retailExpenseRequest.Year;

            var spName = retailExpenseRequest.Caption == null ? StoredProcedureNames.RetailExpense : StoredProcedureNames.RetailExpenseAccounts;

            if (retailExpenseRequest.Caption != null && retailExpenseRequest.BranchCode == "ALL")
            {
                throw new Exception("Branch Code is required for Accounts");
            }

            if (retailExpenseRequest.Caption != null)
            {
                return await _sqlDataAccess.SPLoadData<dynamic>(spName, new
                {
                    pBranch = retailExpenseRequest.BranchCode,
                    pCaption = retailExpenseRequest.Caption,
                    pStaffID = retailExpenseRequest.StaffId,
                    pMonth = retailExpenseRequest.Month,
                    pYear = retailExpenseRequest.Year
                });
            }

            string sql = $"exec [dbo].[{spName}]" +
                $"@pDirectorateCode = @DirectorateCode ," +
                $"@pRegionCode = @RegionCode," +
                $"@pClusterCode = @ClusterCode," +
                $"@pBranchCode = @BranchCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, retailExpenseRequest);
        }

        public async Task<dynamic> GetRetailExpenseTransactions(GetRetailExpenseTransactions request)
        {
            var maxDateInDb = await _commonService.GetMaxDate();
            request.Month = (request.Month == null) ? maxDateInDb.Month : request.Month;
            request.Year = (request.Year == null) ? maxDateInDb.Year : request.Year;

            var spName = StoredProcedureNames.RetailExpenseTransactions;

            string sql = $"exec [dbo].[{spName}]" +
                $"@pBranch = @BranchCode," +
                $"@pGlSub = @GLSubHeadCode," +
                $"@pStaffID = @StaffId," +
                $"@pMonth = @Month," +
                $"@pYear = @Year";

            return await _sqlDataAccess.LoadQueryData<dynamic>(sql, request);
        }
    }
}
