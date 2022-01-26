using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    public class Addition : Operator
    {

        public override double Calculate(List<IShape> shapes)
        {
            double result = 0;
            foreach (IShape shape in shapes)
            {
                result += shape.GetMeasureValue();
            }
            return result;
        }


        // alternative way of calculating multiple shapes
        public override double Calculate(IShape x, IShape y)
        {
            double result = x.GetMeasureValue() + y.GetMeasureValue();
            return result;
        }
        public override double AddAll(List<double> results)
        {
            double result = 0;
            foreach (double value in results)
            {
                result += value;
            }
            return result;
        }
    }
}
