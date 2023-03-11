
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class GetMPRReport
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ZoneCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string SbuCode { get; set; } = "ALL";
        public string AccountOfficerCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        [Description("Total[0], CCY[1]")]
        public BalanceSheetType BalanceSheetType { get; set; } = BalanceSheetType.TOTAL;
        public int? Month { get; set; }
        public int? Year { get; set; }
    }    
    
    public class GetMPRIncomeReport
    {
        public string DirectorateCode { get; set; } = "ALL";
        public string RegionCode { get; set; } = "ALL";
        public string ZoneCode { get; set; } = "ALL";
        public string BranchCode { get; set; } = "ALL";
        public string SbuCode { get; set; } = "ALL";
        public string Caption { get; set; }
        public string AccountOfficerCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

      public class GetMPRIncomeStatementAccount
      {
          public string Caption { get; set; } = "ALL";
          public string StaffId { get; set; } = "ALL";
          public int? Month { get; set; }
          public int? Year { get; set; }
      }


    public class GetMPRLandingViewReport
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
    }

    public enum BalanceSheetType
    {
        [Description("Total")]
        TOTAL,
        [Description("CCY")]
        CCY
    }
}
