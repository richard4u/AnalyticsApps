using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Domain
{
    public class AccountStatus
    {
        public string DirectorateCode { get; set; }
        public string RegionCode { get; set; }
        public string ClusterCode { get; set; }
        public string BranchCode { get; set; }
        public string SbuCode { get; set; }
        public string AccountOfficerCode { get; set; }
        public string StaffId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
