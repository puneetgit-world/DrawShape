using DrawShape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShape.Helpers
{
    public static class ShapePathHelper
    {

        public static ShapePath PathForBox(double width, double height)
        {
            var shapePath = new ShapePath(ShapePathType.Box);
            shapePath.SetSize(width, height);
            var canvasCenterPos = GetCenterOfCanvas(shapePath.Size);

            shapePath.AddCordinate(canvasCenterPos.XPoint - (width / 2), canvasCenterPos.YPoint - (height / 2));
            return shapePath;
        }

        public static ShapePath PathForTriangle(double width, double height, bool hasNoEqualAngle = false)
        {
            var shapePath = new ShapePath(ShapePathType.Line);
            shapePath.SetSize(width, height);
            var canvasCenterPos = GetCenterOfCanvas(shapePath.Size);

            shapePath.AddCordinate(canvasCenterPos.XPoint, canvasCenterPos.YPoint + (hasNoEqualAngle ? -(height / 2) : 0));
            shapePath.AddCordinate(canvasCenterPos.XPoint - (hasNoEqualAngle ? (width * .25) : (width / 2)), canvasCenterPos.YPoint + (height / 2));
            shapePath.AddCordinate(canvasCenterPos.XPoint + (hasNoEqualAngle ? (width * .75) : (width / 2)), canvasCenterPos.YPoint + (height / 2));
            return shapePath;
        }

        public static ShapePath PathForPolygon(double side, int numberOfSides)
        {
            var shapePath = new ShapePath(ShapePathType.Line);
            shapePath.SetSize(side, side);
            var canvasCenterPos = GetCenterOfCanvas(shapePath.Size);

            shapePath.AddCordinate(canvasCenterPos.XPoint + side * Math.Cos(0), canvasCenterPos.YPoint + side * Math.Sin(0));

            for (var i = 1; i <= numberOfSides; i += 1)
            {
                shapePath.AddCordinate((canvasCenterPos.XPoint + side * Math.Cos(i * 2 * Math.PI / numberOfSides)), canvasCenterPos.YPoint + side * Math.Sin(i * 2 * Math.PI / numberOfSides));
            }

            return shapePath;
        }

        public static Size DetermineCanvasSize(Size shapeSize)
        {
            var higherDimension = Math.Max(shapeSize.Width, shapeSize.Height);
            var canvasSize = higherDimension + (higherDimension * 2); // Make Canvas 200% larger than actual shape to fit in
            return new Size
            {
                Width = canvasSize,
                Height = canvasSize
            };
        }

        public static ShapePathCordinate GetCenterOfCanvas(Size shapeSize, double xOffsetPercentage = 0, double yOffsetPercentage = 0)
        {
            var canvasSize = DetermineCanvasSize(shapeSize);
            return new ShapePathCordinate
            {
                XPoint = (canvasSize.Width / 2) + ((canvasSize.Width / 2) * (xOffsetPercentage / 100)),
                YPoint = (canvasSize.Height / 2) + ((canvasSize.Height / 2) * (yOffsetPercentage / 100))
            };
        }
    }
}