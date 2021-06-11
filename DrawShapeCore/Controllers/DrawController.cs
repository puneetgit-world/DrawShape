using DrawShapeCore.Helpers;
using DrawShapeCore.Models;
using DrawShapeCore.Models.Enums;
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
        const string SOMETHING_WENT_WRONG_VIEW = "SomethingWentWrong";
        const string NOT_SUPPORTED_VIEW = "NotSupported";        

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
        [ValidateAntiForgeryToken]
        public IActionResult ParseInput(string instruction)
        {
            try
            {
                if (string.IsNullOrEmpty(instruction)) return RedirectToAction(NOT_SUPPORTED_VIEW);
                TempData["instruction"] = instruction;
                var parsedInstruction = LanguageHelper.ParseInstruction(instruction);
                return RedirectToAction(parsedInstruction.ShapeType.ToString(), parsedInstruction.Size);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }

        }

        public IActionResult Circle(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForCircle(size.Radius));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Circle);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }

        public IActionResult Rectangle(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForRectangle(size.Width, size.Height));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Rectangle);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }

        public IActionResult IsoscelesTriangle(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForIsoscelesTriangle(size.Width, size.Height));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.IsoscelesTriangle);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }

        public IActionResult ScaleneTriangle(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForScaleneTriangle(size.Width, size.Height));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.ScaleneTriangle);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }

        public IActionResult EquilateralTriangle(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForEquilateralTriangle(size.Width));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.EquilateralTriangle);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Square(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForSquare(size.Width));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Square);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Parallelogram(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForParallelogram(size.Width, size.Height));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Parallelogram);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Pentagon(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForPentagon(size.Width));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Pentagon);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Hexagon(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForHexagon(size.Width));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Hexagon);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Heptagon(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForHeptagon(size.Width));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Heptagon);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Octagon(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForOctagon(size.Width));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Octagon);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }
        public IActionResult Oval(Size size)
        {
            try
            {
                var viewModel = new CanvasViewModel(_shapePathProvider.PathForOval(size.Width,size.Height));
                viewModel.HasValidMeasurements = ValidationHelper.HasValidateMeasurements(size, ShapeType.Oval);
                return View(CANVAS_VIEW, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace ?? string.Empty);
                return View(SOMETHING_WENT_WRONG_VIEW);
            }
        }

        public IActionResult NotSupported()
        {
            return View();
        }
    }
}
