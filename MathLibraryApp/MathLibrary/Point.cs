using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Point : PointVectorBase
    {
        public static readonly Point Origin = new Point();

        /// <summary>
        /// Creates a Point instance with given x, y, z coordinates
        /// </summary>
        /// <param name="x">X coordinate (default = 0)</param>
        /// <param name="y">Y coordinate (default = 0)</param>
        /// <param name="z">Z coordinate (default = 0)</param>
        public Point(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Create a copy of sourcePoint.
        /// </summary>
        /// <param name="sourcePoint">The Point instance to be copied.</param>
        public Point(Point sourcePoint)
        {
            X = sourcePoint.X;
            Y = sourcePoint.Y;
            Z = sourcePoint.Z;
        }

        /// <summary>
        /// Calculates the distance between this Point and endPoint.
        /// </summary>
        /// <param name="endPoint">The Point to calculate the distance to.</param>
        /// <returns>double representing the distance between this and endPoint.</returns>
        public double DistanceTo(Point endPoint)
        {
            return CalculateDistanceTo(endPoint);
        }

        /// <summary>
        /// Summs an array of Vectors.
        /// </summary>
        /// <param name="addends">The Vectors to be summed.</param>
        /// <returns>An instance of Point where the addends sum is pointing to.</returns>
        public Point Add(params Vector[] addends)
        {
            return CalculateSum(addends).AsPoint();
        }
    }
}
