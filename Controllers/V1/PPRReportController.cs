using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class PPRReportController : Controller
    {
        private readonly IPPRService _pPRService;

        public PPRReportController(IPPRService pPRService)
        {
            _pPRService = pPRService;
        }

        [HttpGet(ApiRoutes.Reports.PPR_Report.GetAll)]
        public async Task<IActionResult> GetPPRReport(GetPPRRequest request)
        {
            try
            {
                var data = await _pPRService.GetPPRReport(request);
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

    }
}
