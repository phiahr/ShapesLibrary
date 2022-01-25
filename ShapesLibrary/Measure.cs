using System;
namespace ShapesLibrary
{
    public abstract class Measure<TShape>
    {
        public abstract double GetValue(TShape shape);
    }
}
