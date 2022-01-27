using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    public class Multiplication : Operator
    {
        public override double Calculate(List<Shape> shapes)
        {
            double result = 1;
            foreach (Shape shape in shapes)
            {
                result *= shape.GetMeasureValue();
            }
            return result;
        }


        // alternative way
        public override double AddAll(List<double> results)
        {
            double result = 1;
            foreach (double value in results)
            {
                result *= value;
            }
            return result;
        }

        public override double Calculate(Shape x, Shape y)
        {
            double result = x.GetMeasureValue() * y.GetMeasureValue();
            return result;
        }
    }
}
