using System;
namespace ShapesLibrary
{
    public class CuboidArea : Measure<Cuboid>
    {
        public override double GetValue(Cuboid cuboid)
        {
            return 2 * (cuboid.Width * cuboid.Height) + 2 * (cuboid.Width * cuboid.Depth) + 2 * (cuboid.Height * cuboid.Depth);
        }
    }
}
