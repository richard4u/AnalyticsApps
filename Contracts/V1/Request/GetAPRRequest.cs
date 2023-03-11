using System.ComponentModel;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{

    public class GetAPRRequest
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ZoneCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string SbuCode { get; set; } = "ALL";
        public string AccountOfficerCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public string Filter { get; set; } 
        public APRFilterType FilterType { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int Limit { get; set; } = 20;
    }


    public class GetAPRReqestQuery
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ZoneCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string SbuCode { get; set; } = "ALL";
        public string AccountOfficerCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string AccountQuery { get; set; } = "ALL";
    }

    public enum APRFilterType
    {
        [Description("Top")]
        TopFilter,
        [Description("Bottom")]
        BottomFilter,
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
