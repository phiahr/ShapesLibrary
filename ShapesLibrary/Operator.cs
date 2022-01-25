using System;
using System.Collections.Generic;
         
namespace ShapesLibrary
{
    // 7. Making the operator class generic, didn't make any sense to me because you would have to initize it with a specific type (var op = new Operator<Rectangle> or something) and you don't even know the actual type of the shape
    // object in a group because they all have the same base type
    public abstract class Operator
    {
        // 8. I do feel this method kinda makes it unnecessary to have a Group class, but the alternative of having a function that calculates the Measure of 2 Shapes together still leaves the problem of calculating more then two shapes together
        // and then you would have two store the previous result somewhere and keep track of if there is an odd or even number of Shapes since you then can only calculate two Shapes together and not the previous result and a Shape.
        // Example: Group of 3, you calculate the first two and store the result in a double variable, now you have that result and another shape left, which you can't directly calculate together.
        // Still included the alternative way for completion purposes
        public abstract double Calculate(List<Shape> shapes);


        // Alternative way

        // calculate the combined measure of two shapes
        public abstract double Calculate(Shape x, Shape y);
        //public abstract double Calculate(Shape x, Shape y, Shape z);

        // Combine a list of measure values together 
        public abstract double AddAll(List<double> results);
    }
}
