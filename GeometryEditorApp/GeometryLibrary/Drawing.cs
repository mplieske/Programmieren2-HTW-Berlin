using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary
{
    /// <summary>
    /// Class for Drawing with win forms.
    /// </summary>
    public class Drawing
    {
        /// <summary>
        /// immutable list of all curves
        /// </summary>
        public IReadOnlyList<Curve> Curves { get { return _curves.AsReadOnly(); } }
        private List<Curve> _curves = new List<Curve>();

        /// <summary>
        /// creates drawing object with given curves for start.
        /// </summary>
        /// <param name="curves">curves to start with</param>
        public Drawing(Curve[] curves)
        {
            _curves.AddRange(curves);
        }

        /// <summary>
        /// adds a curve to draw on Draw method
        /// </summary>
        /// <param name="newCurve">a curv that is drawn on next call of Draw</param>
        public void AddCurve(Curve newCurve)
        {
            _curves.Add(newCurve);
        }

        /// <summary>
        /// removes curve at index, so it is not drawn anymore.
        /// </summary>
        /// <param name="index">index of curve to remove</param>
        public void RemoveCurve(int index)
        {
            _curves.RemoveAt(index);
        }

        /// <summary>
        /// Draws all curves added to this object
        /// </summary>
        /// <param name="g">the graphics where the curves should be drawn to.</param>
        public void Draw(System.Drawing.Graphics g)
        {
            foreach (var curve in _curves)
            {
                curve.Draw(g);
            }
        }
    }
}
