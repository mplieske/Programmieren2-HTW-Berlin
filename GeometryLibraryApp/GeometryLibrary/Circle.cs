using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace GeometryLibrary
{
    /// <summary>
    /// Circle represents circle in a 3D room.
    /// </summary>
    public class Circle : Curve, ISurface
    {
        /// <summary>
        /// The center of this Circle.
        /// </summary>
        public Point CenterPoint { get; set; }

        /// <summary>
        /// A Vector pointing from the outline to the CenterPoint of this Circle.
        /// </summary>
        public Vector Normal { get; set; }

        /// <summary>
        /// The radius of this Circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// The perimeter of this Circle.
        /// </summary>
        public override double Length { get; }

        public double Area { get { return Math.PI * Math.Pow(Radius, 2); } }

        /// <summary>
        /// Creates an object of Type Circle with given parameters.
        /// </summary>
        /// <param name="centerPoint">The cencter of this Circle (as a positional reference)</param>
        /// <param name="normal">A Vector pointing from the Circles outline to the center of it.</param>
        /// <param name="radius">The radius of this Circle (as a reference for size)</param>
        public Circle(Point centerPoint, Vector normal, double radius)
        {
            CenterPoint = centerPoint;
            Normal = normal;
            Radius = radius;
            Length = Math.PI * 2 * radius;
        }
    }
}
