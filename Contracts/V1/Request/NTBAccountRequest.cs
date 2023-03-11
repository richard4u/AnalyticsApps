using System.ComponentModel.DataAnnotations;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class NTBAccountRequest
    {
        [Required]
        public string AccountOfficerCode { get; set; }
        [Required]
        public string StaffId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
