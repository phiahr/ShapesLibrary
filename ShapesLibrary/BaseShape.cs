//using System;
//namespace ShapesLibrary
//{
//    public abstract class Shape<TShape>
//    {
//        //public abstract double GetValue(TShape shape);
        
//        public Measure<Shape<TShape>> Measure { get; set; }
//        public string Name { get; set; } 

//        public virtual void GetInfo()
//        {
//            Console.WriteLine($"This is a {Name}");
//        }
//    }


//    public abstract class Measure<TShape>
//    {
//        public abstract double GetValue(TShape shape);

//        //public override string ToString()
//        //{
//        //    return $"{Value:F2}";
//        //}
//    }

//    public abstract class Operator<TShape>
//    {
//        public abstract double Calculate(Shape<TShape> x, Shape<TShape> y);
//    }

//    public class Addition<TShape> : Operator<TShape>
//    {
//        public override double Calculate(Shape<TShape> x, Shape<TShape> y)
//        {
//            // bullshit!!
//            double result = x.Measure.GetValue(x) + y.Measure.GetValue(y);
//            return result;
//        }
//    }
//}
