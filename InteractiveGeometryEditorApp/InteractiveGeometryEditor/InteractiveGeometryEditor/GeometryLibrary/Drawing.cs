using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MathLibrary;
using Point = MathLibrary.Point;

namespace GeometryLibrary
{
    /// <summary>
    /// Class for a drawing containing and drawing different types of curves.
    /// </summary>
    public class Drawing
    {
        private readonly List<Curve> _curves = new List<Curve>();

        /// <summary>
        /// The curves of the drawing as <see cref="IReadOnlyList&lt;Point&gt;"/>.
        /// </summary>
        public IReadOnlyList<Curve> Curves => _curves.AsReadOnly();

        /// <summary>
        /// Adds the passed curve to the drawing.
        /// </summary>
        /// <param name="newCurve">The curve to add.</param>
        public void AddCurve(Curve newCurve)
        {
            _curves.Add(newCurve);
        }

        /// <summary>
        /// Removes the curve at the given index from the drawing.
        /// </summary>
        /// <param name="index">The index where the curve will be removed.</param>
        public void RemoveCurve(int index)
        {
            _curves.RemoveAt(index);
        }

        /// <summary>
        /// Draws all contained curves.
        /// </summary>
        /// <param name="g">The graphics context to be used.</param>
        public void Draw(Graphics g)
        {
            foreach (var curve in _curves)
            {
                curve.Draw(g);
            }
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="curves">The curves to be contained in the drawing.</param>
        public Drawing(Curve[] curves)
        {
            _curves.AddRange(curves);
        }
    }
}
