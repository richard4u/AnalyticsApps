using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Contracts.V1.Request
{
    public class GetReportRequest
    {
        public string DirectorateCode { get; set; } = "All";
        public string RegionCode { get; set; } = "All";
        public string ClusterCode { get; set; } = "All";
        public string BranchCode { get; set; } = "All";
        public string SbuCode { get; set; } = "All";
        public string AccountOfficerCode { get; set; } = "All";
        public string StaffId { get; set; } = "All";
        public DateTime? ReportDate { get; set; }
    }
}
