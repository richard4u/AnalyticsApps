using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface IAccountService
    {
        Task<dynamic> GetAccountsStatusReports(GetAccountStatusRequest accountStatusRequest);
        Task<dynamic> GetAccountsStatusAccountReports(GetAccountStatusAccountRequest accountRequest);

        Task<dynamic> GetMTDAccountActivity(MonthlyReportRequest mtdAccountActivity);
        Task<dynamic> GetMTDAccountActivityAccount(GetAccountStatusAccountRequest mtdAccountActivityAccount);

        Task<dynamic> GetYTDAccountActivity(MonthlyReportRequest mtdAccountActivity);
        Task<dynamic> GetYTDAccountActivityAccounts(GetAccountStatusAccountRequest mtdAccountActivityAccount);

        Task <dynamic> GetNewToBankAlatReport(GetAccountStatusRequest reportRequest);
        Task <dynamic> GetNewToBankAlatAccount(NTBAccountRequest ntbAccountRequest);
    }
}
