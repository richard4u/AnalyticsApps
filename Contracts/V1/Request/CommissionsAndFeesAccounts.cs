using System.ComponentModel.DataAnnotations;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class CommissionsAndFeesAccounts
    {
        [Required]
        public string BranchCode { get; set; }
        [Required]
        public string GLSubHeadCode { get; set; }
        [Required]
        public string AccountOfficerCode { get; set; } = "ALL";
        [Required]
        public string StaffId { get; set; } = "ALL";
        public string Type { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
