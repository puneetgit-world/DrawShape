using DrawShape.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShape.Models
{
    public class ShapePath
    {
        public ShapePath()
        {
            Coordinates = new List<ShapePathCordinate>();
            Size = new Size();
        }

        public ShapePath(ShapePathType shapePathType, ShapeType shapeType) : this()
        {
            ShapePathType = shapePathType;
            ShapeType = shapeType;
        }

        [JsonProperty("shapePathType")]
        public ShapePathType ShapePathType { get; set; }

        public ShapeType ShapeType { get; set; }

        [JsonProperty("coordinates")]
        public List<ShapePathCordinate> Coordinates { get; set; }

        [JsonProperty("size")]
        public Size Size { get; set; }

        public void AddCordinate(double x, double y)
        {
            Coordinates.Add(new ShapePathCordinate
            {
                XPoint = x,
                YPoint = y
            });
        }

        public void SetSize(double width, double height)
        {
            Size.Width = width;
            Size.Height = height;
        }
        public void SetRadius(double radius)
        {
            Size = new Size(radius);
        }       
    }




}