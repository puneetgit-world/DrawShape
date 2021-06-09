using DrawShape.Models;
using DrawShape.Models.Enums;
using System;
using System.Text.RegularExpressions;

namespace DrawShape.Helpers
{
    public static class LanguageHelper
    {
        private static readonly string shapePattern = @"(?<=draw\s(\ba\b)|(\ban\b))(.*)(?=with)"; // Find shape to draw
        private static readonly string sizePattern = @"(?<={{MEASUREMENT}}\sof)(.\d+(?:\.\d+)?)"; // Find measurement to shape
        private static readonly string measurementLength = "length";
        private static readonly string measurementRadius = "radius";
        private static readonly string measurementWidth = "width";
        private static readonly string measurementHeight = "height";
        private static readonly string measurementBase = "base";

        public static ParsedInstruction ParseInstruction(string instruction)
        {
            instruction = instruction.ToLowerInvariant();

            var shape = FindShape(instruction);
            var parsedInstruction = new ParsedInstruction(shape);
            if (shape != ShapeType.NotSupported)
            {
                parsedInstruction.Size = GetSize(instruction);
            }

            return parsedInstruction;
        }

        private static ShapeType FindShape(string instruction)
        {
            var rg = new Regex(shapePattern);
            var match = rg.Match(instruction);
            var shapeName = match.Value.Trim();
            var shapeType = ShapeType.NotSupported;
            Enum.TryParse(shapeName.Replace(" ", ""), true, out shapeType);

            return shapeType;
        }

        private static double FindMeasurement(string instruction, string measurement)
        {
            string measurementPattern = sizePattern.Replace("{{MEASUREMENT}}", measurement);
            var rg = new Regex(measurementPattern);
            var match = rg.Match(instruction);
            double value = 0;
            if (!string.IsNullOrEmpty(match.Value))
            {
                double.TryParse(match.Value.Trim(), out value);
            }

            return value;
        }

        private static Size GetSize(string instruction)
        {
            var size = new Size();
            size.Height = FindMeasurement(instruction, measurementHeight);
            size.Width = FindMeasurement(instruction, measurementWidth);

            if (size.Width == 0) size.Width = FindMeasurement(instruction, measurementBase);

            if (size.Width == 0) size.Width = FindMeasurement(instruction, measurementLength);

            size.Radius = FindMeasurement(instruction, measurementRadius);
            return size;
        }
    }
}