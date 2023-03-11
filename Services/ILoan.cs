using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface ILoan
    {
        Task<dynamic> GetLoanReports(GetReportRequest LoanRequest);
        Task<dynamic> GetLoanAccounts(AccountRequest accountRequest);
        Task<dynamic> GetAlcoLoanReports(GetAlcoRequest alcoLoanRequest);
        Task<dynamic> GetAlcoLoanAccounts(GetAlcoAccountRequest accountRequest);
        Task<dynamic> GetNewLoanSalesReport(MonthlyReportRequest newLoanSalesRequest);
        Task<dynamic> GetNewLoanSalesReportAccounts(MonthlyReportAccountsRequest newLoanSalesAccountsRequest);
    }
}
