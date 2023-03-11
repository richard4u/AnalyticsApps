namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class AgencyOnboardingRequest
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ClusterCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string SbuCode { get; set; } = "ALL";
        public string AccountOfficerCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
