using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Domain
{
    public class AccountStatusAccount
    {
        public string AccountOfficerCode { get; set; }
        public string StaffId { get; set; }
        public string Type { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
