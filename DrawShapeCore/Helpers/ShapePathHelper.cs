using DrawShapeCore.Models;
using DrawShapeCore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShapeCore.Helpers
{
    public static class ShapePathHelper
    {

        public static ShapePath PathForBox(double width, double height, ShapeType shapeType)
        {
            var shapePath = new ShapePath(ShapePathType.Box, shapeType);
            shapePath.SetSize(width, height);
            var canvasCenterPos = GetCenterOfCanvas(shapePath.Size, shapeType);

            shapePath.AddCordinate(canvasCenterPos.XPoint - (width / 2), canvasCenterPos.YPoint - (height / 2));
            return shapePath;
        }

        public static ShapePath PathForTriangle(double width, double height, ShapeType shapeType, bool hasNoEqualAngle = false)
        {
            var shapePath = new ShapePath(ShapePathType.Line, shapeType);
            shapePath.SetSize(width, height);
            var canvasCenterPos = GetCenterOfCanvas(shapePath.Size, shapeType, shapeType == ShapeType.ScaleneTriangle ? -50 : 0);

            shapePath.AddCordinate(canvasCenterPos.XPoint, canvasCenterPos.YPoint - (height / 2));
            shapePath.AddCordinate(canvasCenterPos.XPoint - (hasNoEqualAngle ? (width * .25) : (width / 2)), canvasCenterPos.YPoint + (height / 2));
            shapePath.AddCordinate(canvasCenterPos.XPoint + (hasNoEqualAngle ? (width * .75) : (width / 2)), canvasCenterPos.YPoint + (height / 2));
            return shapePath;
        }

        public static ShapePath PathForPolygon(double side, int numberOfSides, ShapeType shapeType)
        {
            var shapePath = new ShapePath(ShapePathType.Line, shapeType);
            shapePath.SetSize(side, side);
            var canvasCenterPos = GetCenterOfCanvas(shapePath.Size, shapeType);

            shapePath.AddCordinate(canvasCenterPos.XPoint + side * Math.Cos(0), canvasCenterPos.YPoint + side * Math.Sin(0));

            for (var i = 1; i <= numberOfSides; i += 1)
            {
                shapePath.AddCordinate((canvasCenterPos.XPoint + side * Math.Cos(i * 2 * Math.PI / numberOfSides)), canvasCenterPos.YPoint + side * Math.Sin(i * 2 * Math.PI / numberOfSides));
            }

            return shapePath;
        }

        public static Size DetermineCanvasSize(Size shapeSize, ShapeType shapeType)
        {
            double canvasSide = 0;
            switch (shapeType)
            {

                case ShapeType.Rectangle:
                case ShapeType.Square:
                case ShapeType.EquilateralTriangle:
                case ShapeType.IsoscelesTriangle:
                case ShapeType.ScaleneTriangle:
                case ShapeType.Oval:
                    canvasSide = Math.Max(shapeSize.Width, shapeSize.Height);
                    canvasSide = canvasSide + (canvasSide * .10);
                    break;
                case ShapeType.Circle:               
                    canvasSide = shapeSize.Radius * 2;
                    break;
                case ShapeType.Pentagon:
                    canvasSide = shapeSize.Width * 2;
                    break;
                case ShapeType.Hexagon:
                case ShapeType.Heptagon:
                    canvasSide = shapeSize.Width * 3;
                    break;
                case ShapeType.Octagon:
                    canvasSide = shapeSize.Width * 4;
                    break;
                case ShapeType.Parallelogram:
                    canvasSide = Math.Max(shapeSize.Width, shapeSize.Height);
                    canvasSide = canvasSide * 1.30;
                    break;
            }

            return new Size
            {
                Width = canvasSide,
                Height = canvasSide
            };
        }

        public static ShapePathCordinate GetCenterOfCanvas(Size shapeSize, ShapeType shapeType, double xOffsetPercentage = 0, double yOffsetPercentage = 0)
        {
            var canvasSize = DetermineCanvasSize(shapeSize, shapeType);
            return new ShapePathCordinate
            {
                XPoint = (canvasSize.Width / 2) + ((canvasSize.Width / 2) * (xOffsetPercentage / 100)),
                YPoint = (canvasSize.Height / 2) + ((canvasSize.Height / 2) * (yOffsetPercentage / 100))
            };
        }
    }
}