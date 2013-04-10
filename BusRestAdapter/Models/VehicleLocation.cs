using System.Runtime.Serialization;

namespace BusRestAdapter.Models
{
    [DataContract(Name="vehicle")]
    public class VehicleLocation
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name="routeTag")]
        public string RouteTag { get; set; }

        [DataMember(Name="dirTag")]
        public string DirTag { get; set; }

        [DataMember(Name="lat")]
        public string Latitude { get; set; }

        [DataMember(Name="long")]
        public string Longitude { get; set; }

        [DataMember(Name="secssincereport")]
        public int SecondsSinceLastReport { get; set; }
 
        [DataMember(Name="predictible")]
        public bool Predictible { get; set; }

        [DataMember(Name="heading")]
        public short Heading { get; set; }
    }
}
