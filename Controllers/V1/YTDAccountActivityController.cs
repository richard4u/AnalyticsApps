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

    public class YTDAccountActivityController : Controller
    {
        private readonly IAccountService _accountService;
        public YTDAccountActivityController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiRoutes.Reports.YTDAccountActivityByCluster.GetAll)]
        public async Task<IActionResult> GetYTDAccountActivity(
          MonthlyReportRequest reportRequest)
        {
            var data = await _accountService.GetYTDAccountActivity(reportRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.YTDAccountActivityByCluster.GetAccounts)]
        public async Task<IActionResult> GetYTDAccountActivityAccounts(
            GetAccountStatusAccountRequest accountStatusRequest)
        {
            var data = await _accountService.GetYTDAccountActivityAccounts(accountStatusRequest);
            return new OkObjectResult(data);
        }
    }
}
