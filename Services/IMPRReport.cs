using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
  public interface IMPRReport
  {
    Task<dynamic> GetMPRBalanceSheetReport(GetMPRReport request);
    Task<dynamic> GetMPRBalanceSheetReportTest(GetMPRReport request);
    Task<dynamic> GetMPRIncomeStatementReport(GetMPRIncomeReport request);
    Task<dynamic> GetMPRLandingViewData(GetMPRLandingViewReport request);
    Task <dynamic> GetMPRIncomeStatementAccount(GetMPRIncomeStatementAccount request);
  }
}
