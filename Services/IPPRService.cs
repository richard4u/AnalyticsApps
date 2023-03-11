using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface IPPRService
    {
        Task<dynamic> GetPPRReport(GetPPRRequest PPRRequest);
    }
}
