using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShape.Models.ViewModels
{
    public class CanvasViewModel
    {
        public CanvasViewModel()
        {
            ErrorMessages = new List<string>();
        }

        public CanvasViewModel(ShapePath shapeToDraw) : this()
        {
            ShapeToDraw = shapeToDraw;
        }
        public List<string> ErrorMessages { get; set; }
        public ShapePath ShapeToDraw { get; set; }
    }
}