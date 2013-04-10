using System.Runtime.Serialization;

namespace BusRestAdapter.Models
{
    [DataContract]
    public class Agency
    {
        [DataMember]
        public string Tag { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ShortTitle { get; set; }

        [DataMember]
        public string RegionTitle { get; set; }

    }

    [DataContract]
    public class Route
    {
        [DataMember]
        public int Tag { get; set; }
        
        [DataMember]
        public string Title { get; set; }
    
        [DataMember]
        public string ShortTitle { get; set; }
    }
}
