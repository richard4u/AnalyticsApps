using WemaAnalyticsAPI.Contracts.V1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Services
{
    public interface IDeposit
    {
       Task<dynamic> GetDepositReports(GetReportRequest depositRequest);
       Task<dynamic> GetDepositAccounts(AccountRequest accountRequest);
       Task<dynamic> GetAlcoDepositReports(GetAlcoRequest alcoDepositRequest);
       Task<dynamic> GetAlcoDepositAccounts(GetAlcoAccountRequest accountRequest);
    }
}
