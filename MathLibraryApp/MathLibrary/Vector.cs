using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// A simple class representing a mathematical vector with handy methods. Base class is PointVectorBase.
    /// </summary>
    public class Vector : PointVectorBase
    {
        public static readonly Vector Zero = new Vector();
        public static readonly Vector One = new Vector(1, 1, 1);
        public static readonly Vector XDir = new Vector(1, 0, 0);
        public static readonly Vector YDir = new Vector(0, 1, 0);
        public static readonly Vector ZDir = new Vector(0, 0, 1);

        public double Length { get { return Zero.CalculateDistanceTo(this); } }

        /// <summary>
        /// Initializes the Vector with given x, y, z values.
        /// </summary>
        /// <param name="x">X value of Vector.</param>
        /// <param name="y">Y value of Vector.</param>
        /// <param name="z">Z value of Vector.</param>
        public Vector(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes the vector as a copy of another Vector.
        /// </summary>
        /// <param name="sourceVector">The Vector to be copied.</param>
        public Vector(Vector sourceVector)
        {
            X = sourceVector.X;
            Y = sourceVector.Y;
            Z = sourceVector.Z;
        }

        /// <summary>
        /// Adds this Vector with other Vectors.
        /// </summary>
        /// <param name="addends">The Vectors wich are added to this Vector.</param>
        /// <returns>A new Vector wich is the sum of this Vector and addends.</returns>
        public Vector Add(params Vector[] addends)
        {
            return CalculateSum(addends).AsVector();
        }

        /// <summary>
        /// Subtracts other Vectors from this Vector.
        /// </summary>
        /// <param name="subtrahends">Vectors to subtract.</param>
        /// <returns>Returns the difference between this Vector and subtrahends.</returns>
        public Vector Subtract(params Vector[] subtrahends)
        {
            Vector firstSubtrahend = new Vector(subtrahends[0]);

            for (int i = 1; i < subtrahends.Length; i++)
            {
                firstSubtrahend.X -= subtrahends[i].X;
                firstSubtrahend.Y -= subtrahends[i].Y;
                firstSubtrahend.Z -= subtrahends[i].Z;
            }

            return firstSubtrahend;
        }

        /// <summary>
        /// Multiplies this Vector salar.
        /// </summary>
        /// <param name="scalarFactor">The scalar factor to multiply this Vector with.</param>
        /// <returns>Return new Vector.</returns>
        public Vector MultiplyScalar(double scalarFactor)
        {
            Vector product = new Vector(this);
            product.X *= scalarFactor;
            product.Y *= scalarFactor;
            product.Z *= scalarFactor;
            return product;
        }

        /// <summary>
        /// Performs a cross product on this Vector and b.
        /// </summary>
        /// <param name="b">Vector to calculate cross product with.</param>
        /// <returns>Returns a new Vector wich is the cross product of this and b.</returns>
        public Vector CrossProduct(Vector b)
        {
            Vector c = new Vector();

            c.X = this.Y * b.Z - this.Z * b.Y;
            c.Y = this.Z * b.X - this.X * b.Z;
            c.Z = this.X * b.Y - this.Y * b.X;

            return c;
        }

        /// <summary>
        /// Performs a dot multiplication with this and b.
        /// </summary>
        /// <param name="b">Vector to calculate dot product with.</param>
        /// <returns>Returns the dot product of this and b. (new Vector)</returns>
        public double DotProduct(Vector b)
        {
            double dotProduct = this.X * b.X +
                                this.Y * b.Y +
                                this.Z * b.Z;

            return dotProduct;
        }

        /// <summary>
        /// Normalizes this Vector.
        /// </summary>
        /// <returns>Returns a new Vector wich is this Vector but normalized.</returns>
        public Vector Normalize()
        {
            return MultiplyScalar(1 / Length);
        }

        /// <summary>
        /// Evaluates if this Vector is collinear to another Vector.
        /// </summary>
        /// <param name="b">Other Vector.</param>
        /// <param name="tolerance">If the karthesian values of the cross product are smaller than tolerance, true is returned.</param>
        /// <returns>Returns true if collinear.</returns>
        public bool AreCollinear(Vector b, double tolerance = PointVectorBase.Tolerance)
        {
            Vector crossProduct = CrossProduct(b);
            return crossProduct.X < tolerance
                && crossProduct.Y < tolerance
                && crossProduct.Z < tolerance;
        }
    }
}
