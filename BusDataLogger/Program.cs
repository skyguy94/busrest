using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using RestSharp;

namespace BusDataLogger
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

    class Program
    {
#if DEBUG
        private const string BaseUrl = "http://localhost:18675/api/";
#else
        private const string BaseUrl = "http://busrest1.apphb.com/api/";
#endif

        static void Main(string[] args)
        {
            Console.WriteLine("Console Started On:" + DateTime.Now);
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("VehicleLocations/{agency}/{route}");
            request.AddParameter("agency", "sf-muni");
            request.AddParameter("route", "N");

            while (true)
            {
                var data = client.Execute<List<VehicleLocation>>(request);
                Console.WriteLine("Retrieved {0} records from system. Logging", data.Data.Count);

                using (var writer = new StreamWriter(File.Open("busdata.txt", FileMode.Append)))
                {
                    foreach (var bus in data.Data)
                    {
                        writer.WriteLine("{0},{1},{2},{3},{4},{5}", DateTime.Now, bus.Id, bus.Latitude, bus.Longitude, bus.Heading, bus.SecondsSinceLastReport);
                    }
                }
                Thread.Sleep(30*1000);
            }
        }
    }
}
