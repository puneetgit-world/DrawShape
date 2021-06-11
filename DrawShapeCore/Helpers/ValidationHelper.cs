using DrawShapeCore.Models;
using DrawShapeCore.Models.Enums;

namespace DrawShapeCore.Helpers
{
    public static class ValidationHelper
    {
        public static bool HasValidateMeasurements(Size size, ShapeType shapeType)
        {

            if (size == null) return false;

            bool needWidth = false;
            bool needHeight = false;
            bool needRadius = false;
            switch (shapeType)
            {
                case ShapeType.IsoscelesTriangle:
                case ShapeType.ScaleneTriangle:
                    needWidth = true;
                    needHeight = true;
                    break;                    
                case ShapeType.EquilateralTriangle:
                    needWidth = true;
                    break;
                case ShapeType.Square:
                    needWidth = true;
                    break;
                case ShapeType.Rectangle:
                case ShapeType.Parallelogram:
                    needWidth = true;
                    needHeight = true;
                    break;
                case ShapeType.Pentagon:
                case ShapeType.Hexagon:
                case ShapeType.Heptagon:
                case ShapeType.Octagon:
                    needWidth = true;
                    break;
                case ShapeType.Circle:
                    needRadius = true; 
                    break;
                case ShapeType.Oval:
                    needWidth = true;
                    needHeight = true;
                    break;
                default:
                    break;
            }

            return (needWidth ? size.Width > 0 : true) && (needHeight ? size.Height > 0 : true) && (needRadius ? size.Radius > 0 : true);

        }
    }
}
