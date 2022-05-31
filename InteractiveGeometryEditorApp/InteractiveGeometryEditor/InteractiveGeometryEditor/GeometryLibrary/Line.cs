using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MathLibrary;
using Point = MathLibrary.Point;

namespace GeometryLibrary
{
    /// <summary>
    /// Class for lines in 3D space.
    /// </summary>
    public class Line : Curve
    {
        /// <summary>
        /// The start point of the line.
        /// </summary>
        public Point StartPoint { get; set; }

        /// <summary>
        /// The end point of the line.
        /// </summary>
        public Point EndPoint { get; set; }

        /// <summary>
        /// The length of the line.
        /// </summary>
        public override double Length => StartPoint.DistanceTo(EndPoint);

        /// <summary>
        /// The direction of the line as a normalized vector
        /// </summary>
        public Vector Direction => new Vector(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y, EndPoint.Z - StartPoint.Z).Normalize();

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="g">The graphics context to be used.</param>
        public override void Draw(Graphics g)
        {
            g.DrawLine(DrawPen, (float)StartPoint.X, (float)StartPoint.Y, (float)EndPoint.X, (float)EndPoint.Y);
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        public Line(Point startPoint, Point endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }
    }
}
