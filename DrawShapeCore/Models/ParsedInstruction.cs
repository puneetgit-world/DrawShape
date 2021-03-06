using DrawShapeCore.Models.Enums;

namespace DrawShapeCore.Models
{
    public class ParsedInstruction
    {
        public ParsedInstruction()
        {
            Size = new Size();
        }

        public ParsedInstruction(ShapeType shapeType) : this()
        {
            ShapeType = shapeType;
        }
        public ShapeType ShapeType { get; set; }
        public Size Size { get; set; }
    }
}