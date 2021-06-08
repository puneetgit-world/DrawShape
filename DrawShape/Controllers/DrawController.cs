using DrawShape.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrawShape.Controllers
{
    public class DrawController : Controller
    {
        private readonly IShapePathProvider _shapePathProvider;

        public DrawController(IShapePathProvider shapePathProvider)
        {
            _shapePathProvider = shapePathProvider;
        }


        // GET: Draw
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Circle(double radius)
        {
            return View("Canvas", _shapePathProvider.PathForCircle(radius));
        }

        public ActionResult Rectangle(double width, double height)
        {
            return View("Canvas", _shapePathProvider.PathForRectangle(width, height));
        }

        public ActionResult IsoscelesTriangle(double width, double height)
        {
            return View("Canvas", _shapePathProvider.PathForIsoscelesTriangle(width, height));
        }

        public ActionResult ScaleneTriangle(double width, double height)
        {
            return View("Canvas", _shapePathProvider.PathForScaleneTriangle(width, height));
        }

        public ActionResult EquilateralTriangle(double side)
        {
            return View("Canvas", _shapePathProvider.PathForEquilateralTriangle(side));
        }
        public ActionResult Square(double side)
        {
            return View("Canvas", _shapePathProvider.PathForSquare(side));
        }
        public ActionResult Parallelogram(double width, double height)
        {
            return View("Canvas", _shapePathProvider.PathForParallelogram(width, height));
        }
        public ActionResult Pentagon(double side)
        {
            return View("Canvas", _shapePathProvider.PathForPentagon(side));
        }
        public ActionResult Hexagon(double side)
        {
            return View("Canvas", _shapePathProvider.PathForHexagon(side));
        }
        public ActionResult Heptagon(double side)
        {
            return View("Canvas", _shapePathProvider.PathForHeptagon(side));
        }
        public ActionResult Octagon(double side)
        {
            return View("Canvas", _shapePathProvider.PathForOctagon(side));
        }
        public ActionResult Oval(double radius)
        {
            return View("Canvas", _shapePathProvider.PathForOval(radius));
        }
    }
}