using System;

namespace MathLibrary
{
    /// <summary>
    /// Class for points in 3D space.
    /// </summary>
    public class Point : PointVectorBase
    {
        public static readonly Point Origin = new Point(0.0, 0.0, 0.0);

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        public Point(double x = 0, double y = 0, double z = 0)
            : base(x, y, z)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="sourcePoint">The <see cref="Point"/>to be copied.</param>
        public Point(Point sourcePoint)
            : base(sourcePoint)
        {
        }

        public double DistanceTo(Point endPoint)
        {
            return CalculateDistanceTo(endPoint);
        }

        /// <summary>
        /// Calculates the summation between this point and the passed addends.
        /// </summary>
        /// <param name="addends">The addends to add.</param>
        /// <returns>The calculated sum.</returns>
        public Point Add(params Vector[] addends)
        {
            return CalculateSum(addends).AsPoint();
        }
    }
}
