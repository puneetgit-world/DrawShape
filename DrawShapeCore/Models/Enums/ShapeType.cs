using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DrawShapeCore.Models.Enums
{
    public enum ShapeType
    {
        NotSupported,
        [Description("Isosceles Triangle")]
        IsoscelesTriangle,
        [Description("Scalene Triangle")]
        ScaleneTriangle,
        [Description("Equilateral Triangle")]
        EquilateralTriangle,
        Rectangle,
        Square,
        Parallelogram,
        Pentagon,
        Hexagon,
        Heptagon,
        Octagon,
        Circle,
        Oval,
    }
}