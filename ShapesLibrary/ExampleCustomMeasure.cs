using System;
namespace ShapesLibrary
{
    public class ExampleCustomMeasure<TShape> : Measure<TShape> where TShape: Shape<TShape>
    {
        public override double GetValue(TShape shape)
        {
            if (shape.GetType() == typeof(Circle))
            {
                var circle = (Circle)(object)shape;
                return circle.Radius * 2;
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                var rect = (Rectangle)(object)shape;
                return rect.Width * 7;
            }
            else
            {
                return 3;
            }
        }
    }

}
