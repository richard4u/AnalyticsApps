using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Domain
{
    public class AlcoAccountReport
    {
        public string AccountOfficerCode { get; set; }
        public string StaffId { get; set; }
        public string Type { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}
