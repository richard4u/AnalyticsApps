using System;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Services
{
    public interface ICommonService
    {
        Task<dynamic> GetDirectorates(DateTime? maxDate);
        Task<dynamic> GetRetailStructure(int? month, int? year);
        Task<DateTime> GetMaxDate();

        Task<dynamic> GetExchangeRates();

        Task<dynamic> GetDirectoratesRetail(int? month, int? year);
        Task<dynamic> GetRegionsRetail(string directorateCode, int? month, int? year);
        Task<dynamic> GetClustersRetail(string regionCode, int? month, int? year);
        Task<dynamic> GetZones(string regionCode, int? month, int? year);
        Task<dynamic> GetBranchesRetail(string clusterCode, int? month, int? year);
        Task<dynamic> GetBranchesMain(string zoneCode, int? month, int? year);
        Task<dynamic> GetSbus(string branchCode, int? month, int? year);
        Task<dynamic> GetAccountOfficers(string branchCode, string sbuCode, int? month, int? year);
        Task<DateTime> GetMonthAndYearAsync(int? month, int? year);
        Task<dynamic> GetTransactionsAsync(string branchCode, string glAccount, int? month, int? year);
        Task<dynamic> GetGLAccountsAsync(string branchCode, int? month, int? year);
        Task<dynamic> GetCaptions();
        Task<dynamic> GetBranchesAccounts(string branchCode, string caption, string staffId, int? month, int? year);
        Task<dynamic> GetDepartments();
        Task<dynamic> GetGlSubHeads();
    }
}
