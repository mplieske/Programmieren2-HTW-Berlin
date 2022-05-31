using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MathLibrary;
using Point = MathLibrary.Point;

namespace GeometryLibrary
{
    /// <summary>
    /// Class for circles in 3D space.
    /// </summary>
    public class Circle : Curve, ISurface
    {
        /// <summary>
        /// The center point of the circle.
        /// </summary>
        public Point CenterPoint { get; set; }

        /// <summary>
        /// The normal of the circle.
        /// </summary>
        public Vector Normal { get; set; }

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// The length of the circle.
        /// </summary>
        public override double Length => 2.0 * Math.PI * Radius;

        /// <summary>
        /// Draws a circle.
        /// </summary>
        /// <param name="g">The graphics context to be used.</param>
        public override void Draw(Graphics g)
        {
            // Build a rectangle to describe the circle
            float x = (float)(CenterPoint.X - Radius);
            float y = (float)(CenterPoint.Y - Radius);
            float diameter = 2f * (float)Radius;
            RectangleF rectangle = new RectangleF(x, y, diameter, diameter);
            g.DrawEllipse(DrawPen, rectangle);
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="centerPoint">The center point.</param>
        /// <param name="normal">The normal.</param>
        /// <param name="radius">The radius.</param>
        public Circle(Point centerPoint, Vector normal, double radius)
        {
            this.CenterPoint = centerPoint;
            this.Normal = normal;
            this.Radius = radius;
        }

        /// <summary>
        /// The area of the circle.
        /// </summary>
        public double Area => Math.PI * Radius * Radius;
    }
}
