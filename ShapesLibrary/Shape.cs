using System;
namespace ShapesLibrary
{
    // 1. Shape not generic, because then you can't create a List of type Shape (List<Shape<??>>), which is necessary for a group of shapes
    // 2. Base class Shape has no measure property because you would need a generic type, which would mean making Shape generic, which leads to problem 1.
    // 3. You could write a non-generic interface which Shape inherits from and define shapes in group such as "List<IShape> shapes", then a group of shapes still wouldn't have access to the Measure property because of problem 2, which is necessary for the calculation.
    // 4. GetMeasureValue is necessary so a list of Shape type objects (Group.shapes) can have the combined measures calculated
    public abstract class Shape<TShape> : IShape
    {
        public Measure<TShape> Measure { get; set; }
        public double GetMeasureValue()
        {
            dynamic p = this;
            return Measure.GetValue(p);
        }
    }
}
