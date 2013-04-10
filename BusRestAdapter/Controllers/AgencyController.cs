using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Xml.Linq;
using BusRestAdapter.Models;

namespace BusRestAdapter.Controllers
{
    public class AgencyController : ApiController
    {
        private const string _rootUrl = "http://webservices.nextbus.com/service/publicXMLFeed?command=agencyList";

        public IEnumerable<Agency> Get()
        {
            var request = WebRequest.Create(_rootUrl);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                if (stream == null) return Enumerable.Empty<Agency>();

                var xml = XDocument.Load(stream).Element("body").Elements("agency");
                var agencies = xml.Select(CreateAgencyObject).ToList();
                return agencies;
            }
        }

        private static Agency CreateAgencyObject(XElement arg)
        {
            var agency = new Agency
                {
                    Tag = arg.Attribute("tag").Value,
                    Title = arg.Attribute("title").Value,
                    //ShortTitle = arg.Attribute("shortTitle").Value,
                    RegionTitle = arg.Attribute("regionTitle").Value
                };

            return agency;
        }

        // GET api/<controller>/5
        public string Get(string tag)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}