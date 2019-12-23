using Newtonsoft.Json;
using OrenburgTourismFM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrenburgTourismFM.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual PlaceType PlaceType { get; set; }
        [JsonIgnore]
        public virtual IList<Meeting> Meetings { get; set; }
    }
}