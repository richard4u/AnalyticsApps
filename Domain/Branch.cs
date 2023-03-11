using System.Collections.Generic;

namespace WemaAnalyticsAPI.Domain
{
    public class Branch
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }

        public  List<AccountOfficer> AccountOfficers { get; set; }
    }
}
