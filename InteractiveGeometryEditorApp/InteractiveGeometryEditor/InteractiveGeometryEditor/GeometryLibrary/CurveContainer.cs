using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GeometryLibrary
{
    /// <summary>
    /// A Collection of Curves.
    /// </summary>
    /// <typeparam name="T">Type of Curve to be contained.</typeparam>
    public class CurveContainer<T> : List<T> where T : Curve
    {
        /// <summary>
        /// Draws each element contained in this container.
        /// </summary>
        /// <param name="g">Graphics context to draw on.</param>
        public void DrawElements(Graphics g)
        {
            ForEach(e =>
            {
                e.Draw(g);
            });
        }
    }
}
