using System;
using System.Collections.Generic;

namespace ShapesLibrary
{

    public abstract class Shape
    {
        public abstract double GetMeasureValue();
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


    public class Rectangle: Shape
    {
        public int Width { get; }
        public int Height { get; }

        public Measure<Rectangle> Measure { get;set; }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
            Measure = new RectangleArea();
        }

        public override double GetMeasureValue()
        {
            return Measure.GetValue(this);
        }
    }

    public abstract class Operator
    {
        // calculate the combined measure of two shapes
        public abstract double Calculate(Shape x, Shape y);
        //public abstract double Calculate(Shape x, Shape y, Shape z);

        // add a list of measure values together 
        public abstract double AddAll(List<double> results);

        public abstract double CalculateGroup(Group group);

    }

    public class Addition: Operator
    {
        public override double Calculate(Shape x, Shape y)
        {
            double result = x.GetMeasureValue() + y.GetMeasureValue();
            return result;
        }

        public double Calculate<T1,T2>(T1 x, T2 y) where T1: Shape where T2: Shape
        {
            double result = x.GetMeasureValue() + y.GetMeasureValue();
            return result;
        }

        // es benötigt immer noch einer Funktion die zwei doubles als Parameter akzeptiert um mehr als 2 Shape Measures zusammenzurechnen (altes Ergebnis, also Summe der vorherigen beiden Shapes, plus nächste Shape)
        public override double AddAll(List<double> results)
        {
            double result = 0;
            foreach (double value in results) {
                result += value;
            }
            return result;
        }

        // Problem einer Funktion die zwei Shapes als Parameter annimmt, wie rechnet man 3 Shapes zusammen, die ersten beiden werden zusammengerechnet, dann hat man eine Zahl und ein verbleibendes Shape objekt.
        // Nun kann man das verbleibende Shape Objekt mit keiner weiteren Shape zusammen rechnen nur mit der Zahl. Extra ne Funktion zum zusammenrechnen einer Zahl und Shape macht keinen Sinn, außerdem müsste man tracken ob in einer Gruppe
        // eine gerade oder ungerade Anzahl an Shapes sind, etc.
        public override double CalculateGroup(Group group)
        {
            double result = 0;
        
            foreach (Shape shape in group.shapes)
            {
                result += shape.GetMeasureValue();
            }
            return result;
        }
    }

    public class Group
    {
        public readonly List<Shape> shapes;
        public Group()
        {
            shapes = new List<Shape>();            
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void RemoveShape(Shape shape)
        {
            shapes.Remove(shape);
        }

        public double Foo(Operator op)
        {
            List<double> results = new List<double>();

            for (int i = 0; i < shapes.Count-1; i++)
            {
                // bullshit, now adding the every value twice, except the first and last
                results.Add(op.Calculate(shapes[i], shapes[i + 1]));
            }
            double result = op.AddAll(results);
            return result;
        }

        public double CalculateMeasure(Operator op)
        {
            List<double> results = new List<double>();
            int i = 0;
            if (shapes.Count % 2 == 1)
            {
                results.Add(shapes[0].GetMeasureValue());
                i = 1;
            }
            for (; i < shapes.Count - 1; i+=2)
            {
                // bullshit, now adding the every value twice, except the first and last
                results.Add(op.Calculate(shapes[i], shapes[i + 1]));
            }
            double result = op.AddAll(results);
            return result;
        }
    }

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
