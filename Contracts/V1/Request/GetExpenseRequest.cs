namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class GetExpenseRequest
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ZoneCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string Caption { get; set; } = "ALL";
        public string GLSubHeadCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public string Type { get; set; } = "mtd";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

    public class GetHeadOfficeExpenseRequest
    {
        public string DepartmentCode { get; set; } = "ALL";
        public string Captions { get; set; }
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }


    public class GetRetailExpenseRequest
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ClusterCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string Caption { get; set; } 
        public string GLSubHeadCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
