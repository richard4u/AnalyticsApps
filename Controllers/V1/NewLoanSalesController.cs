using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class NewLoanSalesController : Controller
    {
        private readonly ILoan _loansService;
        public NewLoanSalesController(ILoan loansService)
        {
            _loansService = loansService;
        }

        [HttpGet(ApiRoutes.Reports.NewLoanSalesByCluster.GetAll)]
        public async Task<IActionResult> GetNewLoanSalesReport(
          MonthlyReportRequest reportRequest)
        {
            var data = await _loansService.GetNewLoanSalesReport(reportRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.NewLoanSalesByCluster.GetAccounts)]
        public async Task<IActionResult> GetGetNewLoanSalesReportAccounts(
            MonthlyReportAccountsRequest accountsRequest)
        {
            var data = await _loansService.GetNewLoanSalesReportAccounts(accountsRequest);
            return new OkObjectResult(data);
        }
    }
}
