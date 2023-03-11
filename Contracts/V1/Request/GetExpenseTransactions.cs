using System.ComponentModel.DataAnnotations;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class GetExpenseTransactions
    {
        public string BranchCode { get; set; } = "ALL";
        public string GLSubHeadCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; } = "Monthly";
     } 

    public class GetHeadOfficeTransactions
    {
        [Required]
        public string DepartmentCode { get; set; } = "ALL";
        [Required]
        public string GLCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

    public class GetRetailExpenseTransactions
    {
        public string BranchCode { get; set; } = "ALL";
        public string GLSubHeadCode { get; set; } = "ALL";
        public string StaffId { get; set; } = "ALL";
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
