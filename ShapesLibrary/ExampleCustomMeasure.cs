using System;
namespace ShapesLibrary
{
    public class ExampleCustomMeasure: Measure<Circle>
    {
        public override double GetValue(Circle circle)
        {
            return circle.Radius * 2;
        }
    }
}
