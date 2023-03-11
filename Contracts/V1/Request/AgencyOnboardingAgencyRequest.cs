using System.ComponentModel.DataAnnotations;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class AgencyOnboardingAgencyRequest
    {
        [Required]
        public string AccountOfficerCode { get; set; } = "ALL";
        [Required]
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
