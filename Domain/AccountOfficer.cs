using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Domain
{
    public class AccountOfficer
    {
        public string StaffNumber { get; set; }

        public string StaffName { get; set; }

        public Sbu Sbu { get; set; }
    }
}
