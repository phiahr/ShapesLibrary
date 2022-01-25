using System;
namespace ShapesLibrary
{
    public class Cuboid : Shape
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }
        public Measure<Cuboid> Measure { get; set; }

        public Cuboid(int width, int height, int depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;

            // Default Measure
            Measure = new CuboidArea();
        }

        public override double GetMeasureValue()
        {
            return Measure.GetValue(this);
        }
    }
}
