using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// Base class for Vector and Point for 3 Dimensions.
    /// </summary>
    public class PointVectorBase
    {
        public const double Tolerance = 1E-10;

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        /// <summary>
        /// Creates a PointVectorBase with given values.
        /// </summary>
        /// <param name="x">X value of PointVectorBase instance (default is 0)</param>
        /// <param name="y">Y value of PointVectorBase instance (default is 0)</param>
        /// <param name="z">Z value of PointVectorBase instance (default is 0)</param>
        protected PointVectorBase(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Creates an exact copy of sourcePvBase.
        /// </summary>
        /// <param name="sourcePvBase">The PointVectorBase to copy.</param>
        protected PointVectorBase(PointVectorBase sourcePvBase)
        {
            X = sourcePvBase.X;
            Y = sourcePvBase.Y;
            Z = sourcePvBase.Z;
        }

        /// <summary>
        /// Converts this PointVectorBase into an instance of Point.
        /// </summary>
        /// <returns>This PointVectorBase as a Point.</returns>
        public Point AsPoint()
        {
            return (Point)this;
        }

        /// <summary>
        /// Converts this PointVectorBase into an instance of Vector.
        /// </summary>
        /// <returns>This PointVectorbase as a Vector.</returns>
        public Vector AsVector()
        {
            return (Vector)this;
        }

        /// <summary>
        /// Returns JSON-string representing this PointVectorBase.
        /// </summary>
        /// <returns>String representing this PointVectorBase.</returns>
        public override string ToString()
        {
            return $"{{ X: '{X}', Y: '{Y}', Z: '{Z}', Tolerance: '{Tolerance}' }}";
        }

        /// <summary>
        /// Calculates the distance between this PointVectorBase and endPvBase.
        /// </summary>
        /// <param name="endPvBase">The PointVectorBase to calculate the distance to.</param>
        /// <returns>Distance between this PointVectorBase and endPvBase as double.</returns>
        protected double CalculateDistanceTo(PointVectorBase endPvBase)
        {
            double deltaX = endPvBase.X - X;
            double deltaY = endPvBase.Y - Y;
            double deltaZ = endPvBase.Z - Z;

            // sqrt(x² + y² + z²)
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2));
        }

        /// <summary>
        /// Calculates the sum of addends.
        /// </summary>
        /// <param name="addends">List of Vectors the add together.</param>
        /// <returns>PointVectorBase representing the sum of addends.</returns>
        protected PointVectorBase CalculateSum(params Vector[] addends)
        {
            double sumX = 0;
            double sumY = 0;
            double sumZ = 0;

            foreach (Vector addend in addends)
            {
                sumX += addend.X;
                sumY += addend.Y;
                sumZ += addend.Z;
            }

            return new PointVectorBase(sumX, sumY, sumZ);
        }
    }
}
