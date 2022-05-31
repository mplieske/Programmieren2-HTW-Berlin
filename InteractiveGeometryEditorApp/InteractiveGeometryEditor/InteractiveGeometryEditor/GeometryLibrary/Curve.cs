using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GeometryLibrary
{
    /// <summary>
    /// Common base class for different types of curves.
    /// </summary>
    public abstract class Curve
    {
        /// <summary>
        /// The length of the curve.
        /// </summary>
        public abstract double Length { get; }

        /// <summary>
        /// The pen used to draw the different types of curves. 
        /// </summary>
        public Pen DrawPen { get; set; } = new Pen(Color.Black);

        /// <summary>
        /// Draws a curve.
        /// </summary>
        /// <param name="g">The graphics context to be used.</param>
        public abstract void Draw(Graphics g);
    }
}
