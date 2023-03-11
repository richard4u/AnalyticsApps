using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface IAgencyOnboardingService
    {
        Task<dynamic> GetAgencyOnboardingByCluster(AgencyOnboardingRequest agencyOnboardingRequest);
        Task<dynamic> GetAgencyOnboardingAgents(AgencyOnboardingAgencyRequest agencyRequest);
    }
}
