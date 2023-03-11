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
    public class MTDAccountActivityController : Controller
    {
        private readonly IAccountService _accountService;
        public MTDAccountActivityController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiRoutes.Reports.MTDAccountActivityByCluster.GetAll)]
        public async Task<IActionResult> GetMTDAccountActivity(
          MonthlyReportRequest reportRequest)
        {
            var data = await _accountService.GetMTDAccountActivity(reportRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.MTDAccountActivityByCluster.GetAccounts)]
        public async Task<IActionResult> GetMTDAccountActivityAccount(
            GetAccountStatusAccountRequest accountStatusRequest)
        {
            var data = await _accountService.GetMTDAccountActivityAccount(accountStatusRequest);
            return new OkObjectResult(data);
        }

    }
}
