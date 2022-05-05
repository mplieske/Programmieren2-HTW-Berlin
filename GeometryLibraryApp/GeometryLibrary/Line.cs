using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace GeometryLibrary
{
    /// <summary>
    /// Class representing a line (derived from Curve)
    /// </summary>
    public class Line : Curve
    {
        /// <summary>
        /// A Point representing the start of this Line.
        /// </summary>
        public Point StartPoint { get; set; }

        /// <summary>
        /// A Point representing the end of this Line.
        /// </summary>
        public Point EndPoint { get; set; }

        /// <summary>
        /// The length of this Line (distance between StartPoint and EndPoint.
        /// </summary>
        public override double Length { get { return StartPoint.DistanceTo(EndPoint); } }

        /// <summary>
        /// The direction of this Line (if you could say so).
        /// It is the normalized Vector from StartPoint to EndPoint.
        /// </summary>
        public Vector Direction { get; }

        /// <summary>
        /// Creates a Line object with given values.
        /// </summary>
        /// <param name="startPoint">Point where Line begins.</param>
        /// <param name="endPoint">Point where Line ends.</param>
        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;

            double deltaX = endPoint.X - startPoint.X;
            double deltaY = endPoint.Y - startPoint.Y;
            double deltaZ = endPoint.Z - startPoint.Z;
            Vector startToEndPointVector = new Vector(deltaX, deltaY, deltaZ);
            Direction = startToEndPointVector.Normalize();
        }
    }
}
