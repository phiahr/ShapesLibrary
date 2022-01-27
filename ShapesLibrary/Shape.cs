using System;
namespace ShapesLibrary
{
    // 1. To define a list of Shapes (for the group class) a non-generic base class or interface is needed because otherwise the type would have to be specified in the definition (eg. List<Shape<???>>)
    // 2. Non-generic class cannot have a measure property, because that would need a generic type, but since we need to know the MeasureValue from a shape object even as a base type (Shape type object) for the group calculation, GetMeasureValue()
    // was the only solution I could think of
    public abstract class Shape
    {
        public abstract double GetMeasureValue();
    }

    public abstract class Shape<TShape> : Shape
    {
        public Measure<TShape> Measure { get; set; }
        public override double GetMeasureValue()
        {
            dynamic p = this;
            return Measure.GetValue(p);
        }
    }
}
