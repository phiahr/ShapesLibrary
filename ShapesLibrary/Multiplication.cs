using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    public class Multiplication : Operator
    {
        public override double Calculate(List<IShape> shapes)
        {
            double result = 1;
            foreach (IShape shape in shapes)
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

        public override double Calculate(IShape x, IShape y)
        {
            double result = x.GetMeasureValue() * y.GetMeasureValue();
            return result;
        }
    }
}
