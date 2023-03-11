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
    public class AccountsStatusController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsStatusController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiRoutes.Reports.AccountStatusByCluster.GetAll)]
        public async Task<IActionResult> GetAccountsStatusReports(
          GetAccountStatusRequest accountStatusRequest)
        {
            var data = await _accountService.GetAccountsStatusReports(accountStatusRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.AccountStatusByCluster.GetAccounts)]
        public async Task<IActionResult> GetAccountsStatusByAccountsReports(
            GetAccountStatusAccountRequest accountStatusRequest)
        {
            var data = await _accountService.GetAccountsStatusAccountReports(accountStatusRequest);
            return new OkObjectResult(data);
        }
    }
}
