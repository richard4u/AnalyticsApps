using System.Collections.Generic;

namespace WemaAnalyticsAPI.Domain
{
    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public List<Cluster> Clusters { get; set; } = new List<Cluster>();
        public List<Zone> Zones { get; set; } = new List<Zone>();
    }
}
