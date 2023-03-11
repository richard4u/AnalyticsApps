using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class APRReportController : Controller
    {

        private readonly IAPRService _aprService;
       
        public APRReportController(IAPRService aprService)
        {
            _aprService = aprService;
        }

        [HttpGet(ApiRoutes.Reports.APR_Report.GetAll)]
        public async Task<IActionResult> GetAPRReport(GetAPRRequest request)
        {
            try
            {
                var data = await _aprService.GetAPRReport(request);
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

        [HttpGet(ApiRoutes.Reports.APR_Report.GetFilters)]
        public async Task<IActionResult> GetAPRReportFilters()
        {
            try
            {
                var data = await _aprService.GetAPRFilters();
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

        [HttpGet(ApiRoutes.Reports.APR_Report.GetViaQuery)]
        public async Task<IActionResult> GetAPRReportViaQuery(GetAPRReqestQuery reqestQuery)
        {
            try
            {
                var data = await _aprService.GetAPRReport(reqestQuery);
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }
    }
}
