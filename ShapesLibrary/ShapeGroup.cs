//using System;
//using System.Collections.Generic;

//namespace ShapesLibrary
//{
//    public class ShapeGroup
//    {
//        List<BaseShape> shapes;

//        public ShapeGroup()
//        {
//            shapes = new List<Shape>();
//        }

//        public double CalculateMeasure(Operator op)
//        {
//            double result = shapes[0].Measure.Value;

//            if (shapes.Count > 1)
//            {
//                foreach (Shape shape in shapes.GetRange(1, shapes.Count - 1))
//                {
//                    result = op.Calculate(result, shape.Measure.Value);
//                }
//            }

//            return result;
//        }

//        public void AddShape(Shape shape)
//        {
//            shapes.Add(shape);
//        }

//        public void RemoveShape(Shape shape)
//        {
//            shapes.Remove(shape);
//        }
//    }
//}

//}
