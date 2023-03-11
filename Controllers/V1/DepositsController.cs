using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.V1.Controllers
{
    public class DepositsController : ControllerBase
    {
        private readonly IDeposit _depositService;

        public DepositsController(IDeposit depositService)
        {
            _depositService = depositService;
        }

        [HttpGet(ApiRoutes.Reports.DepositsByCluster.GetAll)]
        public async Task<IActionResult> GetDepositReports(
           GetReportRequest depositRequest)
        {
            var data = await _depositService.GetDepositReports(depositRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.AlcoDepositsByCluster.GetAll)]
        public async Task<IActionResult> GetAlcoDepositReports(
            GetAlcoRequest depositRequest)
        {
            var data = await _depositService.GetAlcoDepositReports(depositRequest);
            return new OkObjectResult(data);
        }

        // Accounts
        [HttpGet(ApiRoutes.Reports.DepositsByCluster.GetAccounts)]
        public async Task<IActionResult> GetDepositReportAccount(
            AccountRequest accountRequest)
        {
            var data = await _depositService.GetDepositAccounts(accountRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.AlcoDepositsByCluster.GetAccounts)]
        public async Task<IActionResult> GetAlcoDepositReportAccount(
            GetAlcoAccountRequest accountRequest)
        {
            var data = await _depositService.GetAlcoDepositAccounts(accountRequest);
            return new OkObjectResult(data);
        }
    }
}
