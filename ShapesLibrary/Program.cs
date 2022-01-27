using System;
using System.Collections.Generic;

namespace ShapesLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(6, 8);
            var circ = new Circle(6);
            var cub = new Cuboid(2, 4, 6);

            Console.WriteLine($"Rectangle with width {rect.Width} and height {rect.Height} has measure: {rect.Measure.GetValue(rect)}");
            Console.WriteLine($"Circle with radius {circ.Radius} has measure: {circ.Measure.GetValue(circ)}");
            Console.WriteLine($"Cuboid with width {cub.Width}, height {cub.Height} and depth {cub.Depth} has measure: {cub.Measure.GetValue(cub)}");

            // ExampleCustomMeasure for a rectangle type shape
            var customMeasure = new ExampleCustomMeasure<Rectangle>();
            Console.WriteLine($"ExampleCustomMeasure for the rectangle {customMeasure.GetValue(rect)}");
            Console.WriteLine("Did not set the measure of the rectangle to the ExampleCustomMeasure however");


            Console.WriteLine("Set new measure for circle: ");
            var customMeasureCircle = new ExampleCustomMeasure<Circle>();
            circ.Measure = customMeasureCircle;
            Console.WriteLine($"Circle has new measure: {customMeasureCircle.GetValue(circ)}");

            Console.WriteLine("Set new measure for cuboid: ");
            cub.Measure = new CuboidVolume();
            Console.WriteLine($"Cuboid has new measure: {cub.Measure.GetValue(cub)}");

            Console.WriteLine("Create new Group");
            var group = new Group();

            group.AddShape(rect);
            Console.WriteLine("Added Rectangle to group");

            group.AddShape(circ);
            Console.WriteLine("Added Circle to group");

            group.AddShape(cub);
            Console.WriteLine("Added Cuboid to group");

            var op = new Multiplication();
            Console.WriteLine("Calculate group measure with Multiplication set as the parameter");
            var groupMeasure = group.CalculateMeasure(op);
            Console.WriteLine($"Result: {groupMeasure}");

        }
    }
}
