using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Xml.Linq;
using BusRestAdapter.Models;

namespace BusRestAdapter.Controllers
{
    public class VehicleLocationsController : ApiController
    {
        private const string _rootUrl = "http://webservices.nextbus.com/service/publicXMLFeed?command=vehicleLocations&a={0}&r={1}&t={2}";

        // GET api/values
        public IEnumerable<VehicleLocation> Get()
        {
            return Enumerable.Empty<VehicleLocation>();
        }

        // GET api/values/5
        public IEnumerable<VehicleLocation> Get(string agency, string route)
        {
            var url = string.Format(_rootUrl, agency, route, 0);
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                if (stream == null) return null;

                var xml = XDocument.Load(stream).Element("body").Elements("vehicle");
                var locations = xml.Select(CreateVehicleLocationObject).ToList();
                return locations;
            }
        }

        private static VehicleLocation CreateVehicleLocationObject(XElement arg)
        {
            var result = new VehicleLocation();
            result.Id = arg.Attribute("id").Value;
            result.RouteTag = arg.Attribute("routeTag").Value;
            result.DirTag = arg.Attribute("dirTag") != null ? arg.Attribute("dirTag").Value : string.Empty;
            result.Latitude = arg.Attribute("lat").Value;
            result.Longitude = arg.Attribute("lon").Value;
            result.SecondsSinceLastReport = arg.Attribute("secsSinceReport").Value;
            result.Predictible = arg.Attribute("predictable").Value;
            result.Heading = arg.Attribute("heading").Value;
            result.Speed = arg.Attribute("speedKmHr").Value;
            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
