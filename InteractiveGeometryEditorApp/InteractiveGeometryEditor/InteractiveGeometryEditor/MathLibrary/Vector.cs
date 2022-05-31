using System;

namespace MathLibrary
{
    /// <summary>
    /// Class for vectors in 3D space.
    /// </summary>
    public class Vector : PointVectorBase
    {
        public static readonly Vector Zero = new Vector(0.0, 0.0, 0.0);
        public static readonly Vector One = new Vector(1.0, 1.0, 1.0);
        public static readonly Vector XDir = new Vector(1.0, 0.0, 0.0);
        public static readonly Vector YDir = new Vector(0.0, 1.0, 0.0);
        public static readonly Vector ZDir = new Vector(0.0, 0.0, 1.0);

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        public Vector(double x = 0, double y = 0, double z = 0)
            : base(x, y, z)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="sourceVector">The <see cref="Vector"/>to be copied.</param>
        public Vector(Vector sourceVector)
            : base(sourceVector)
        {
        }

        /// <summary>
        /// The length of the vector.
        /// </summary>
        public double Length => CalculateDistanceTo(Point.Origin);

        /// <summary>
        /// Calculates the summation between this vector and the passed addends.
        /// </summary>
        /// <param name="addends">The addends to add.</param>
        /// <returns>The calculated sum.</returns>
        public Vector Add(params Vector[] addends)
        {
            return CalculateSum(addends).AsVector();
        }

        /// <summary>
        /// Calculates the difference between this vector and the passed subtrahends.
        /// </summary>
        /// <param name="subtrahends">The subtrahends to add.</param>
        /// <returns>The calculated difference.</returns>
        public Vector Subtract(params Vector[] subtrahends)
        {
            Vector difference = new Vector(X, Y, Z);
            foreach (Vector subtrahend in subtrahends)
            {
                difference.X -= subtrahend.X;
                difference.Y -= subtrahend.Y;
                difference.Z -= subtrahend.Z;
            }
            return difference;
        }

        /// <summary>
        /// Multiply this vector by the passed factor.
        /// </summary>
        /// <param name="scalarFactor">The factor to calculate the vector with.</param>
        /// <returns>The calculated product.</returns>
        public Vector MultiplyScalar(double scalarFactor)
        {
            return new Vector(
                scalarFactor * X,
                scalarFactor * Y,
                scalarFactor * Z
            );
        }

        /// <summary>
        /// Calculates the cross product between this vector and the passed vector.
        /// </summary>
        /// <param name="b">The vector to calculate the cross product for.</param>
        /// <returns>The calculated cross product.</returns>
        public Vector CrossProduct(Vector b)
        {
            return new Vector(
                Y * b.Z - Z * b.Y,
                Z * b.X - X * b.Z,
                X * b.Y - Y * b.X
            );
        }

        /// <summary>
        /// Calculates the dot product between this vector and the passed vector.
        /// </summary>
        /// <param name="b">The vector to calculate the dot product for.</param>
        /// <returns>The calculated dot product.</returns>
        public double DotProduct(Vector b)
        {
            return X * b.X + Y * b.Y + Z * b.Z;
        }

        /// <summary>
        /// Calculates the normalized vector with a length of 1.
        /// </summary>
        /// <returns>The normalized vector.</returns>
        public Vector Normalize()
        {
            double length = Length;
            return new Vector(this.X/length, this.Y/length, this.Z/Length);
        }

        /// <summary>
        /// Determines whether this vector and the passed vector are collinear.
        /// </summary>
        /// <param name="b">The other vector.</param>
        /// <param name="tolerance">The tolerance to use for value comparison.</param>
        /// <returns>true if the two vectors are collinear, otherwise false.</returns>
        public bool AreCollinear(Vector b, double tolerance = PointVectorBase.Tolerance)
        {
            Vector cross = CrossProduct(b);
            return Math.Abs(cross.X) <= tolerance && Math.Abs(cross.Y) <= tolerance && Math.Abs(cross.Z) <= tolerance;
        }
    }
}
