using System.Collections.Generic;

namespace WemaAnalyticsAPI.Domain
{
    public class Directorate
    {
        public string DirectorateCode { get; set; }
        public string DirectorateName { get; set; }
        public List<Region> Regions { get; set; }
    }
}
