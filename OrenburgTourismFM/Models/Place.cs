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
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public virtual PlaceType PlaceType { get; set; }
        public virtual IList<Meeting> Meetings { get; set; }
    }
}