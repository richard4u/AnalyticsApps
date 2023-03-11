using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface ICommissionsAndFeesService
    {
        Task<dynamic> GetCommissionsAndFeesReport(CommissionsAndFeesRequest requests);
        Task<dynamic> GetCommissionsAndFeesReportAccounts(CommissionsAndFeesAccounts requests);
    }
}
