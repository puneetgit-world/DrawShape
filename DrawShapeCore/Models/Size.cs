using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShapeCore.Models
{
    public class Size
    {
        public Size() { }

        public Size(double radius)
        {
            Radius = radius;
            Width = radius * 2;
            Height = radius * 2;
        }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("radius")]
        public double Radius { get; set; }
    }
}