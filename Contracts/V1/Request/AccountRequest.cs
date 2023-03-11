using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class AccountRequest
    {
        [Required]
        public string AccountOfficerCode { get; set; }
        [Required]
        public string StaffId { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}
