using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface IAPRService
    {
        Task<dynamic> GetAPRReport(GetAPRRequest aPRRequest);
        Task<dynamic> GetAPRFilters();
        Task<dynamic> GetAPRReport(GetAPRReqestQuery requestQuery);
    }
}
