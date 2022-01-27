using System;
namespace ShapesLibrary
{
    public class Circle: Shape<Circle>
    {
        // 5. 6., see Rectangle
        public int Radius { get; }

        public Circle(int radius)
        {
            Radius = radius;

            // default Measure
            Measure = new CircleArea();
        }

    }
}
