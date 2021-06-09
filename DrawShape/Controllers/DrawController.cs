using DrawShape.Helpers;
using DrawShape.Models;
using DrawShape.Models.ViewModels;
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
        const string CANVAS_VIEW = "Canvas";

        public DrawController(IShapePathProvider shapePathProvider)
        {
            _shapePathProvider = shapePathProvider;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ParseInput(string instruction)
        {
            TempData["instruction"] = instruction;
            var parsedInstruction = LanguageHelper.ParseInstruction(instruction);
            return RedirectToAction(parsedInstruction.ShapeType.ToString(), parsedInstruction.Size);
        }

        public ActionResult Circle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForCircle(size.Radius));
            return View(CANVAS_VIEW, viewModel);
        }

        public ActionResult Rectangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForRectangle(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }

        public ActionResult IsoscelesTriangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForIsoscelesTriangle(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }

        public ActionResult ScaleneTriangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForScaleneTriangle(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }

        public ActionResult EquilateralTriangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForEquilateralTriangle(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Square(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForSquare(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Parallelogram(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForParallelogram(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Pentagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForPentagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Hexagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForHexagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Heptagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForHeptagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Octagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForOctagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public ActionResult Oval(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForOval(size.Radius));
            return View(CANVAS_VIEW, viewModel);
        }

        public ActionResult NotSupported()
        {
            return View();
        }
    }
}