using System;
namespace ShapesLibrary
{
    public class Circle : Shape
    {
        public int Radius { get; }
        public Measure<Circle> Measure { get; set; }

        public Circle(int radius)
        {
            Radius = radius;

            // default Measure
            Measure = new CircleArea();
        }

        public override double GetMeasureValue()
        {
            return Measure.GetValue(this);
        }
    }
}
