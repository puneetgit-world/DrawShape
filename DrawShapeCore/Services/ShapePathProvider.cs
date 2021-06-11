using DrawShapeCore.Helpers;
using DrawShapeCore.Models;
using DrawShapeCore.Models.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShapeCore.Services
{
    internal class ShapePathProvider : IShapePathProvider
    {
        private readonly ILogger<ShapePathProvider> _logger;

        public ShapePathProvider(ILogger<ShapePathProvider> logger)
        {
            _logger = logger;
        }

        // T R I A N G L E S
        public ShapePath PathForEquilateralTriangle(double side)
        {
            try
            {
                return ShapePathHelper.PathForTriangle(side, side, shapeType: ShapeType.EquilateralTriangle); // Equilateral Triangle has same lenth of sides i.e Same height and width
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForIsoscelesTriangle(double width, double height)
        {
            try
            {
                return ShapePathHelper.PathForTriangle(width, height, shapeType: ShapeType.IsoscelesTriangle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForScaleneTriangle(double width, double height)
        {
            try
            {
                return ShapePathHelper.PathForTriangle(width, height, hasNoEqualAngle: true, shapeType: ShapeType.ScaleneTriangle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // P O L Y G O N

        public ShapePath PathForPentagon(double side)
        {
            try
            {
                return ShapePathHelper.PathForPolygon(side, numberOfSides: 5, shapeType: ShapeType.Pentagon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForHexagon(double side)
        {
            try
            {
                return ShapePathHelper.PathForPolygon(side, numberOfSides: 6, shapeType: ShapeType.Hexagon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        public ShapePath PathForHeptagon(double side)
        {
            try
            {
                return ShapePathHelper.PathForPolygon(side, numberOfSides: 7, shapeType: ShapeType.Heptagon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForOctagon(double side)
        {
            try
            {
                return ShapePathHelper.PathForPolygon(side, numberOfSides: 8,shapeType : ShapeType.Octagon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // B O X E S

        public ShapePath PathForParallelogram(double width, double height)
        {
            try
            {
                var shapePath = new ShapePath(ShapePathType.Line, ShapeType.Parallelogram);
                shapePath.SetSize(width, height);
                var canvasCenterPos = ShapePathHelper.GetCenterOfCanvas(shapePath.Size, ShapeType.Parallelogram,15);

                shapePath.AddCordinate(canvasCenterPos.XPoint - (width / 2), canvasCenterPos.YPoint - (height / 2));
                shapePath.AddCordinate(canvasCenterPos.XPoint + (width / 2), canvasCenterPos.YPoint - (height / 2));
                shapePath.AddCordinate(canvasCenterPos.XPoint + (width * .25), canvasCenterPos.YPoint + (height / 2));
                shapePath.AddCordinate(canvasCenterPos.XPoint - (width * .75), canvasCenterPos.YPoint + (height / 2));
                return shapePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForRectangle(double width, double height)
        {
            try
            {
                return ShapePathHelper.PathForBox(width, height, ShapeType.Rectangle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        public ShapePath PathForSquare(double side)
        {
            try
            {
                return ShapePathHelper.PathForBox(side, side, ShapeType.Square);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForCircle(double radius)
        {
            try
            {
                var shapePath = new ShapePath(ShapePathType.Arc, ShapeType.Circle);
                shapePath.SetRadius(radius);
                var canvasCenterPos = ShapePathHelper.GetCenterOfCanvas(shapePath.Size, ShapeType.Circle);

                shapePath.AddCordinate(canvasCenterPos.XPoint, canvasCenterPos.YPoint);
                return shapePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ShapePath PathForOval(double width, double height)
        {
            try
            {
                var shapePath = new ShapePath(ShapePathType.Ellipse, ShapeType.Oval);
                shapePath.SetSize(width,height);
                var canvasCenterPos = ShapePathHelper.GetCenterOfCanvas(shapePath.Size, ShapeType.Oval);

                shapePath.AddCordinate(canvasCenterPos.XPoint, canvasCenterPos.YPoint);
                return shapePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}