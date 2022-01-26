using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    public class Group
    {
        List<IShape> shapes;
        public Group()
        {
            shapes = new List<IShape>();
        }

        public void AddShape(IShape shape)
        {
            shapes.Add(shape);
        }

        public void RemoveShape(IShape shape)
        {
            shapes.Remove(shape);
        }

        public double CalculateMeasure(Operator op)
        {
            return op.Calculate(shapes);
        }



        // alternative way of calculating group measure
        public double CalculateMeasureAlternative(Operator op)
        {
            List<double> results = new List<double>();
            int i = 0;
            // since stepsize is 2 for the following loop we need an even number of shapes. So if we have an odd number, the first one will be directly added to the results list and skipped in the loop so that the last element won't get left out
            if (shapes.Count % 2 == 1)
            {
                results.Add(shapes[0].GetMeasureValue());
                i = 1;
            }

            // stepsize is 2, to not include the previous shapes[i+1] in the next calculation
            for (; i < shapes.Count - 1; i += 2)
            {
                results.Add(op.Calculate(shapes[i], shapes[i + 1]));
            }
            double result = op.AddAll(results);
            return result;
        }
    }
}
