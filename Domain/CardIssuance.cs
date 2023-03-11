
namespace WemaAnalyticsAPI.Domain
{
    public class CardIssuance
    {
        public string DirectorateCode { get; set; }
        public string RegionCode { get; set; }
        public string ClusterCode { get; set; }
        public string BranchCode { get; set; }
        public string SbuCode { get; set; }
        public string AccountOfficerCode { get; set; }
        public string StaffId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}