using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class CommissionsAndFeesController: ControllerBase
    {
        private readonly ICommissionsAndFeesService _commissionsAndFeesService;
        public CommissionsAndFeesController(ICommissionsAndFeesService commissionsAndFeesService)
        {
            _commissionsAndFeesService = commissionsAndFeesService;
        }

        [HttpGet(ApiRoutes.Reports.CommissionsAndFees.GetAll)]
        public async Task<IActionResult> GetCommissionsAndFeesReport(CommissionsAndFeesRequest request)
        {
            try
            {
                var data = await _commissionsAndFeesService.GetCommissionsAndFeesReport(request);
                return new OkObjectResult(data);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

        [HttpGet(ApiRoutes.Reports.CommissionsAndFees.GetAccounts)]
        public async Task<IActionResult> GetCommissionsAndFeesReportAccounts(CommissionsAndFeesAccounts request)
        {
            try
            {
                var data = await _commissionsAndFeesService.GetCommissionsAndFeesReportAccounts(request);
                return new OkObjectResult(data);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }
    }
}
