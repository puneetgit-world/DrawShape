using DrawShape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShape.Services
{
    public interface IShapePathProvider
    {
        ShapePath PathForRectangle(double width, double height);
        ShapePath PathForIsoscelesTriangle(double width, double height);
        ShapePath PathForScaleneTriangle(double width, double height);
        ShapePath PathForEquilateralTriangle(double side);
        ShapePath PathForSquare(double side);
        ShapePath PathForParallelogram(double width, double height);
        ShapePath PathForPentagon(double side);
        ShapePath PathForHexagon(double side);
        ShapePath PathForHeptagon(double side);
        ShapePath PathForOctagon(double side);
        ShapePath PathForCircle(double radius);
        ShapePath PathForOval(double radius);

    }
}
