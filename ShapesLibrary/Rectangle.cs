using System;
namespace ShapesLibrary
{
    public class Rectangle : Shape<Rectangle>
    {
        // 5. set to public so that a Measure such as RectangleArea can calculate the Area with its properties
        // 6. previously left it as mutable because I thought it might desirable to change the width or height after initializing
        // Of course you could then still write a SetWidth(int x) method, but I felt like that was a matter of preference
        // Still set it to read-only now

        public int Width { get; }
        public int Height { get; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;

            // default Measure
            Measure = new RectangleArea();
        }

    }
}
