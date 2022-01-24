using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    public interface IShape
    {
        public IMeasure GetMeasure();
    }

    //public class Foo
    //{
    //    public Bar Measure { get; set; }
    //}

    public abstract class Shape<T>: IShape
    {
        public Measure<T> Measure { get; set; }
        public IMeasure GetMeasure() {
            return Measure;
        }
        //public IMeasure Measure { get; set; }

    }

    public interface IMeasure
    {
        public double GetFoo(IShape shape);
    }

    //public class Bar
    //{
    //    public double GetValue(IShape shape);
    //}

    public abstract class Measure<T>: IMeasure
    {
        public abstract double GetValue(T shape);
        public double GetFoo(IShape shape)
        {
            return GetValue((T)shape);
        }
    public Measure<T> Cast<X>()
        {
            return this;
        }

    }

    public class Rectangle : Shape<Rectangle>
    {
        public readonly int Width;
        public readonly int Height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;

            // default Measure
            //RectangleArea<Shape> m = new RectangleArea<Shape>();
            //Measure<Shape> foo = m;
            Measure<Rectangle> f = new RectangleArea();

            //f.Cast<Shape>();
            //Measure = f.Cast<Shape>();
            Measure = f;
        }
    }

    //public class Circle : Shape
    //{
    //    public readonly int Radius;

    //    public Circle(int radius)
    //    {
    //        Radius = radius;

    //        // default Measure
    //        Measure = new RectangleArea();
    //    }
    //}

    public class RectangleArea : Measure<Rectangle>
    {
        public override double GetValue(Rectangle rectangle)
        {
            //return 0;
            return rectangle.Width * rectangle.Height;
        }


        //public override double GetValue(Shape shape)
        //{
        //    var rectangle = (Rectangle)shape;
        //    return rectangle.Width * rectangle.Height;
        //}
    }


    // making operator a generic class didn't make any sense, since you don't want to specify any type when you instantiate an operator
    public abstract class Operator
    {
        public abstract double Calculate(IMeasure x, IMeasure y);
    }

    //public class Addition : Operator
    //{
    //    public override double Calculate(IMeasure x, IMeasure y)
    //    {
    //        double result = x + y;
    //        return result;
    //    }
    //}

    public class Group
    {
        List<IShape> shapes;
        public Group()
        {
            shapes = new List<IShape>();
            //var shape = shapes[0];

            //shape.GetMeasure().GetValue(shape);
        }
        //public double CalculateMeasure(Operator op)
        //{

        //}


        //public double CalculateMeasure(Operator op)
        //{
        //    double result = shapes[0].Measure.Value;

        //    if (shapes.Count > 1)
        //    {
        //        foreach (Shape< shape in shapes.GetRange(1, shapes.Count - 1))
        //        {
        //            result = op.Calculate(result, shape.Measure.Value);
        //        }
        //    }

        //    return result;
        //}

        public void AddShape(IShape shape)
        {
            shapes.Add(shape);
        }

        public void foo()
        {
            Console.WriteLine("faea");

            foreach (IShape shape in shapes)
            {
                Console.WriteLine("af");

                Console.WriteLine($"Test:  {shape.GetMeasure().GetFoo(shape)}");
            }
        }
    }

    //public abstract class Shape
    //{
    //    public abstract double GetMeasureValue();
    //}

    //public abstract class Measure<TShape>
    //{
    //    public abstract double GetValue(TShape shape);
    //    public abstract double Calculate(TShape shape);
    //}
    //public class AreaRecttangle: Measure<Rectangle>
    //{


    //    public override double GetValue(Rectangle rect)
    //    {

    //        return Calculate(rect);
    //    }

    //    public override double Calculate(Rectangle rect)
    //    {
    //        return rect.width * rect.height;
    //    }
    //}

    //public class Rectangle : Shape
    //{
    //    public int width;
    //    public int height;
    //    public Measure<Rectangle> _measure;
    //    public Rectangle(int width, int height)
    //    {
    //        this.width = width;
    //        this.height = height;
    //        _measure = new AreaRecttangle();

    //    }
    //    public override double GetMeasureValue()
    //    {
    //        return _measure.GetValue(this);
    //    }
    //}


    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(6, 8);
            var rect2 = new Rectangle(2, 4);
            var rectArea = new RectangleArea();
            rectArea.GetValue(rect2);

            Console.WriteLine($"rect{rectArea.GetValue(rect)}");
            Console.WriteLine($"rect{rectArea.GetValue(rect2)}");

            var group = new Group();
            group.AddShape(rect);
            group.AddShape(rect2);
            group.foo();
        }
    }
}
