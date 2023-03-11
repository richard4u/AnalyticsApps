using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaAnalyticsAPI.Domain
{
    public class Cluster
    {
        public string ClusterCode { get; set; }
        public string ClusterName { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();
    }
}
