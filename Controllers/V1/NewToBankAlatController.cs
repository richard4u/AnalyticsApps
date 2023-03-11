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
    public class NewToBankAlatController : Controller
    {
        private readonly IAccountService _accountService;
        public NewToBankAlatController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiRoutes.Reports.NewToBankAlatByCluster.GetAll)]
        public async Task<IActionResult> GetNewToBankAlatReport(
          GetAccountStatusRequest reportRequest)
        {
            var data = await _accountService.GetNewToBankAlatReport(reportRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.NewToBankAlatByCluster.GetAccounts)]
        public async Task<IActionResult> GetNewToBankAlatAccount(
           NTBAccountRequest ntbAccountRequest)
        {
            var data = await _accountService.GetNewToBankAlatAccount(ntbAccountRequest);
            return new OkObjectResult(data);
        }
    }
}
