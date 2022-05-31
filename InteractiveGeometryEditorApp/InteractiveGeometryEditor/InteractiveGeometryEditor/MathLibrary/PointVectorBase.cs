using System;

namespace MathLibrary
{
    /// <summary>
    /// Common base class for point and vector.
    /// </summary>
    public class PointVectorBase
    {
        /// <summary>
        /// The tolerance used for comparison operations between points and vectors.
        /// </summary>
        public const double Tolerance = 1E-10;

        /// <summary>
        /// x coordinate
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// z coordinate
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        protected PointVectorBase(double x = 0, double y = 0, double z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="sourcePvBase">The <see cref="PointVectorBase"/>to be copied.</param>
        protected PointVectorBase(PointVectorBase sourcePvBase)
        {
            this.X = sourcePvBase.X;
            this.Y = sourcePvBase.Y;
            this.Z = sourcePvBase.Z;
        }

        /// <summary>
        /// Calculates the Euclidean distance between this point and the end point.
        /// </summary>
        /// <param name="endPvBase">The end point</param>
        /// <returns>The calculated distance.</returns>
        protected double CalculateDistanceTo(PointVectorBase endPvBase)
        {
            return Math.Sqrt(Math.Pow(endPvBase.X - this.X, 2) + Math.Pow(endPvBase.Y - this.Y, 2) + Math.Pow(endPvBase.Z - this.Z, 2));
        }

        /// <summary>
        /// Calculates the summation between this point and the passed addends.
        /// </summary>
        /// <param name="addends">The addends to add.</param>
        /// <returns>The calculated sum.</returns>
        protected PointVectorBase CalculateSum(params Vector[] addends)
        {
            PointVectorBase sum = new PointVectorBase(X, Y, Z);
            foreach (Vector addend in addends)
            {
                sum.X += addend.X;
                sum.Y += addend.Y;
                sum.Z += addend.Z;
            }
            return sum;
        }

        /// <summary>
        /// Converts to a point.
        /// </summary>
        /// <returns>The created point.</returns>
        public Point AsPoint()
        {
            return new Point(X, Y, Z);
        }

        /// <summary>
        /// Converts to a vector.
        /// </summary>
        /// <returns>The created vector.</returns>
        public Vector AsVector()
        {
            return new Vector(X, Y, Z);
        }

        /// <summary>
        /// Returns a string that represents the current point vector base.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({X} | {Y} | {Z})";
        }
    }
}
