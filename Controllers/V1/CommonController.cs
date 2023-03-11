using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet(ApiRoutes.Common.GetDirectorates)]
        public async Task<IActionResult> GetDirectorates(DateTime? maxDate)
        {
            var data = await _commonService.GetDirectorates(maxDate);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetRetailStructure)]
        public async Task<IActionResult> GetRetailStructure(int? month, int? year)
        {
            var data = await _commonService.GetRetailStructure(month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetMaxDate)]
        public async Task<IActionResult> GetMaxDate()
        {
            var data = await _commonService.GetMaxDate();

            return new OkObjectResult(data);
        }



        [HttpGet(ApiRoutes.Common.GetDirectoratesRetail)]
        public async Task<IActionResult> GetDirectoratesRetail(int? month, int? year)
        {
            var data = await _commonService.GetDirectoratesRetail(month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetRegionsRetail)]
        public async Task<IActionResult> GetRegionsRetail(string directorateCode, int? month, int? year)
        {
            var data = await _commonService.GetRegionsRetail(directorateCode, month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetClustersRetail)]
        public async Task<IActionResult> GetClustersRetail(string regionCode, int? month, int? year)
        {
            var data = await _commonService.GetClustersRetail(regionCode, month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetZones)]
        public async Task<IActionResult> GetZones(string regionCode, int? month, int? year)
        {
            var data = await _commonService.GetZones(regionCode, month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetBranchesRetail)]
        public async Task<IActionResult> GetBranchesRetail(string clusterCode, int? month, int? year)
        {
            var data = await _commonService.GetBranchesRetail(clusterCode, month, year);

            return new OkObjectResult(data);
        }
        
        [HttpGet(ApiRoutes.Common.GetSbus)]
        public async Task<IActionResult> GetSbus(string branchCode, int? month, int? year)
        {
            var data = await _commonService.GetSbus(branchCode, month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetAccountOfficers)]
        public async Task<IActionResult> GetAccountOfficers(string branchCode, string sbuCode, int? month, int? year)
        {
            var data = await _commonService.GetAccountOfficers(branchCode, sbuCode, month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetTransactions)]
        public async Task<IActionResult> GetTransactions([Required] string branchCode, [Required] string glAccount, int? month, int? year)
        {
            var data = await _commonService.GetTransactionsAsync(branchCode, glAccount, month, year);

            return new OkObjectResult(data);
        }        
        
        //[HttpGet(ApiRoutes.Common.GetGLAccounts)]
        //public async Task<IActionResult> GetGLAccounts([Required] string branchCode, int? month, int? year)
        //{
        //    var data = await _commonService.GetGLAccountsAsync(branchCode, month, year);

        //    return new OkObjectResult(data);
        //} 
        
        [HttpGet(ApiRoutes.Common.GetCaptions)]
        public async Task<IActionResult> GetCaptions()
        {
            var data = await _commonService.GetCaptions();

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetBranchesAccountWithGLSubHeadCodes)]
        public async Task<IActionResult> GetBranchesAccount([Required] string branchCode, [Required] string caption, [Required] string staffId, int? month, int? year)
        {
            var data = await _commonService.GetBranchesAccounts(branchCode, caption, staffId, month, year);

            return new OkObjectResult(data);
        }


        [HttpGet(ApiRoutes.Common.GetExchangeRates)]
        public async Task<IActionResult> GetExchangeRates()
        {
            var data = await _commonService.GetExchangeRates();

            return new OkObjectResult(data);
        }


        [HttpGet(ApiRoutes.Common.GetBranchesMain)]
        public async Task<IActionResult> GetBranchesMain(string zoneCode, int? month, int? year)
        {
            var data = await _commonService.GetBranchesMain(zoneCode, month, year);

            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Common.GetDepartments)]
        public async Task<IActionResult> GetDepartments()
        {
            var data = await _commonService.GetDepartments();
            return new OkObjectResult(data);
        }


        [HttpGet(ApiRoutes.Common.GetGlSubHeads)]
        public async Task<IActionResult> GetGlSubHeads()
        {
            var data = await _commonService.GetGlSubHeads();
            return new OkObjectResult(data);
        }
    }
}
