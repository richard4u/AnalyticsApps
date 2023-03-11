using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class CardIssuanceCardsRequest
    {
        [Required]
        public string AccountOfficerCode { get; set; } = "ALL";
        [Required]
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
