using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShapeCore.Models
{
    public class ShapePathCordinate
    {
        [JsonProperty("xPoint")]
        public double XPoint { get; set; }

        [JsonProperty("yPoint")]
        public double YPoint { get; set; }
    }
}