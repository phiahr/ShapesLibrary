using System;
using System.Collections.Generic;

namespace ShapesLibrary
{

    public interface IShape {
        public double GetMeasureValue();
    }

    public abstract class Shape<TShape>: IShape
    {
        public Measure<TShape> Measure { get; set; }
        public double GetMeasureValue() {
            dynamic p = this;
            return Measure.GetValue(p);
        }
    }

    public abstract class Measure<TShape>
    {
        public abstract double GetValue(TShape shape);
    }
    public class RectangleArea : Measure<Rectangle>
    {
        public override double GetValue(Rectangle rect)
        {

            return rect.Width * rect.Height;
        }
    }


    public class Rectangle: Shape<Rectangle>
    {
        public int Width { get; }
        public int Height { get; }

        //public Measure<Rectangle> Measure { get;set; }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
            Measure = new RectangleArea();
        }
    }

    public class Circle: Shape<Circle>
    {
        public int Radius { get; }
        public Circle(int radius)
        {
            Radius = radius;

            Measure = new CircleArea();
        }
    }

    public class CircleArea: Measure<Circle>
    {
        public override double GetValue(Circle circle)
        {
            return circle.Radius * circle.Radius * Math.PI;
        }
    }

    public class TestMeasure<TShape> : Measure<TShape>
    {
        public override double GetValue(TShape shape)
        {
            return 2;
        }

    public class Cuboid: Shape<Cuboid>
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }

        //public Measure<Rectangle> Measure { get;set; }
        public Cuboid(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            Measure = new TestMeasure<Cuboid>();
        }
    }

    public abstract class Operator
    {
        //public abstract double CalculateGroup(Group group);
        public abstract double Calculate(List<IShape> shapes);

    }

    public class Addition: Operator
    {
        public override double Calculate(List<IShape> shapes)
        {
            double result = 0;
            foreach(IShape shape in shapes)
            {
                result += shape.GetMeasureValue();
            }
            return result;
        }
    }

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
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(6, 8);
            var circ = new Circle(2);
            var cub = new Cuboid(4, 2, 1);


            var rect2 = new Rectangle(2, 4);
            var rectArea = new RectangleArea();
            rectArea.GetValue(rect2);
            Console.WriteLine($"rect{rectArea.GetValue(rect)}");
            Console.WriteLine($"rect{rectArea.GetValue(rect2)}");
            Rectangle x = new Rectangle(2, 4);
            var foo = new Rectangle(1, 2);

            x.Measure.GetValue(x);
            var group = new Group();

            var op = new Addition();
            group.AddShape(rect);
            Console.WriteLine($"group{group.CalculateMeasure(op)}"); //1
            group.AddShape(rect2);
            Console.WriteLine($"group{group.CalculateMeasure(op)}"); //2
            group.AddShape(foo);
            Console.WriteLine($"group{group.CalculateMeasure(op)}"); //3
            group.AddShape(foo);
            Console.WriteLine($"group{group.CalculateMeasure(op)}"); //4
            group.AddShape(foo);
            Console.WriteLine($"group{group.CalculateMeasure(op)}"); //5
            group.AddShape(foo);
            Console.WriteLine($"group{group.CalculateMeasure(op)}"); //6
            group.AddShape(foo);
            Console.WriteLine($"group{group.CalculateMeasure(op)}");
            group.AddShape(foo);
            Console.WriteLine($"group{group.CalculateMeasure(op)}");

        }
    }
}
