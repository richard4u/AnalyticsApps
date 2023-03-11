using System.Collections.Generic;

namespace WemaAnalyticsAPI.Domain
{
    public class Zone
    {
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();
    }
}
