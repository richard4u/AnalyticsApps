using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface IExpenseService
    {
        Task<dynamic> GetBranchesExpenseReports(GetExpenseRequest branchesExpenseRequest);
        Task<dynamic> GetBranchesExpenseTransactionsReports(GetExpenseTransactions branchesExpenseTransactions);
        Task<dynamic> GetHeadOfficeExpenseReports(GetHeadOfficeExpenseRequest request);
        Task<dynamic> GetHeadOfficeExpenseTransactionsReports(GetHeadOfficeTransactions request);
        Task<dynamic> GetRetailExpenseReports(GetRetailExpenseRequest request);
        Task<dynamic> GetRetailExpenseTransactions(GetRetailExpenseTransactions request);
    }
}
