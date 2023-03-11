namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    //public class GetPPRRequest
    //{
    //    public string DirectorateCode { get; set; } = "ALL";
    //    public string RegionCode { get; set; } = "ALL";
    //    public string ZoneCode { get; set; } = "ALL";
    //    public string BranchCode { get; set; } = "ALL";
    //    public string SbuCode { get; set; } = "ALL";
    //    public string AccountOfficerCode { get; set; } = "ALL";
    //    public string StaffId { get; set; } = "ALL";
    //    public int? Month { get; set; }
    //    public int? Year { get; set; }
    //}

    public class GetPPRRequest
    {
        public string GLSubHeadCode { get; set; }
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

    //public enum FilterOptions
    //{
    //    [Description("TopProfitable")]
    //    TopProfitable,
    //    [Description("BottomProfitable")]
    //    BottomProfitable,
    //    [Description("BottomAverageCredit")]
    //    BottomAverageCredit,
    //    [Description("BottomAverageDebit")]
    //    BottomAverageDebit
    //}
}
