using DrawShapeCore.Helpers;
using DrawShapeCore.Models;
using DrawShapeCore.Models.ViewModels;
using DrawShapeCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapeCore.Controllers
{
    public class DrawController : Controller
    {
        
        private readonly ILogger<DrawController> _logger;
        private readonly IShapePathProvider _shapePathProvider;
        const string CANVAS_VIEW = "Canvas";

        public DrawController(IShapePathProvider shapePathProvider, ILogger<DrawController> logger)
        {
            _shapePathProvider = shapePathProvider;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParseInput(string instruction)
        {
            TempData["instruction"] = instruction;
            var parsedInstruction = LanguageHelper.ParseInstruction(instruction);
            return RedirectToAction(parsedInstruction.ShapeType.ToString(), parsedInstruction.Size);
        }

        public IActionResult Circle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForCircle(size.Radius));
            return View(CANVAS_VIEW, viewModel);
        }

        public IActionResult Rectangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForRectangle(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }

        public IActionResult IsoscelesTriangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForIsoscelesTriangle(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }

        public IActionResult ScaleneTriangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForScaleneTriangle(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }

        public IActionResult EquilateralTriangle(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForEquilateralTriangle(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Square(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForSquare(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Parallelogram(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForParallelogram(size.Width, size.Height));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Pentagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForPentagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Hexagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForHexagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Heptagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForHeptagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Octagon(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForOctagon(size.Width));
            return View(CANVAS_VIEW, viewModel);
        }
        public IActionResult Oval(Size size)
        {
            var viewModel = new CanvasViewModel(_shapePathProvider.PathForOval(size.Radius));
            return View(CANVAS_VIEW, viewModel);
        }

        public IActionResult NotSupported()
        {
            return View();
        }
    }
}
