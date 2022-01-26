using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(6, 8);
            var circ = new Circle(3);
            var cub = new Cuboid(4, 2, 1);


            var rect2 = new Rectangle(2, 4);
            var rectArea = new RectangleArea();
            rectArea.GetValue(rect2);
            Console.WriteLine($"rect{rectArea.GetValue(rect)}");
            Console.WriteLine($"rect{rectArea.GetValue(rect2)}");
            Rectangle x = new Rectangle(2, 4);
            var foo = new Rectangle(1, 2);

            var group = new Group(); 

            group.AddShape(cub);
            Console.WriteLine("Added Cuboid to group");

            var op = new Multiplication();
            Console.WriteLine("Calculate group measure with Multiplication set as the parameter");
            var groupMeasure = group.CalculateMeasure(op);

            Console.WriteLine($"Result: {groupMeasure}");

            var customMeasure = new ExampleCustomMeasure<Rectangle>();
            Console.WriteLine(customMeasure.GetValue(rect));
        }
    }
}
