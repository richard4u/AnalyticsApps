using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class GetAlcoAccountRequest
    {
        [Required]
        public string AccountOfficerCode { get; set; }
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}
