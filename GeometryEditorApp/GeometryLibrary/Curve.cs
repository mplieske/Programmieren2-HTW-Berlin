using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometryLibrary
{
    /// <summary>
    /// Abstract class for curves.
    /// </summary>
    public abstract class Curve
    {
        /// <summary>
        /// Abstract property representing the length of a Curve.
        /// </summary>
        public abstract double Length { get; }

        public Pen DrawPen { get; set; } = new Pen(Color.Black);

        public abstract void Draw(Graphics g);
    }
}
