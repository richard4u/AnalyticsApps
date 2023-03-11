using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class LoansController : ControllerBase
    {
        private readonly ILoan _loanService;

        public LoansController(ILoan loanService)
        {
            _loanService = loanService;
        }

        [HttpGet(ApiRoutes.Reports.LoansByCluster.GetAll)]
        public async Task<IActionResult> GetLoanReports(
           GetReportRequest loanRequest)
        {
            var data = await _loanService.GetLoanReports(loanRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.AlcoLoansByCluster.GetAll)]
        public async Task<IActionResult> GetAlcoLoanReports(
            GetAlcoRequest loanRequest)
        {
            var data = await _loanService.GetAlcoLoanReports(loanRequest);
            return new OkObjectResult(data);
        }

        // Accounts
        [HttpGet(ApiRoutes.Reports.LoansByCluster.GetAccounts)]
        public async Task<IActionResult> GetLoanReportAccount(
            AccountRequest accountRequest)
        {
            var data = await _loanService.GetLoanAccounts(accountRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.AlcoLoansByCluster.GetAccounts)]
        public async Task<IActionResult> GetAlcoLoanReportAccount(
            GetAlcoAccountRequest accountRequest)
        {
            var data = await _loanService.GetAlcoLoanAccounts(accountRequest);
            return new OkObjectResult(data);
        }
    }
}
