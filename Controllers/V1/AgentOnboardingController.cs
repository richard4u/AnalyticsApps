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
    public class AgentOnboardingController : Controller
    {
        private readonly IAgencyOnboardingService _agencyService;
        public AgentOnboardingController(IAgencyOnboardingService agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpGet(ApiRoutes.Reports.AgentOnboardingByCluster.GetAll)]
        public async Task<IActionResult> GetAgencyOnboardingByCluster(
          AgencyOnboardingRequest reportRequest)
        {
            var data = await _agencyService.GetAgencyOnboardingByCluster(reportRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.AgentOnboardingByCluster.GetAgency)]
        public async Task<IActionResult> GetAgencyOnboardingAgents(
            AgencyOnboardingAgencyRequest reportRequest)
        {
            var data = await _agencyService.GetAgencyOnboardingAgents(reportRequest);
            return new OkObjectResult(data);
        }
    }

}