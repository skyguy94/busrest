namespace BusRestAdapter.Models
{
    public class VehicleLocation
    {
        public string Id { get; set; }
        public string RouteTag { get; set; }
        public string DirTag { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SecondsSinceLastReport { get; set; }
        public string Predictible { get; set; }
        public string Heading { get; set; }
        public string Speed { get; set; }
    }
}
