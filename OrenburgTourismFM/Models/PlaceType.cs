﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrenburgTourismFM.Models
{
    public class PlaceType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IList<Place> Places { get; set; }
    }
}