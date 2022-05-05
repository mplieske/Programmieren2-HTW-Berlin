using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace GeometryLibrary
{
    public class Polyline : Curve
    {
        private List<Point> _points = new List<Point>();

        public IReadOnlyList<Point> Points { get { return _points.AsReadOnly(); } }
        public override double Length
        {
            get
            {
                double length = 0;

                for (int i = 1; i < _points.Count; i++)
                {
                    Point currentStart = _points[i - 1];
                    Point currentEnd = _points[i];

                    length += currentStart.DistanceTo(currentEnd);
                }

                return length;
            }
        }
        public bool IsClosed
        {
            get
            {
                Point startPoint = _points[0];
                Point endPoint = _points[_points.Count - 1];

                // closed if start and end are same => have same x,y,z coordinates.
                bool closed =
                    startPoint.X == endPoint.X &&
                    startPoint.Y == endPoint.Y &&
                    startPoint.Z == endPoint.Z;

                return closed;
            }
        }
        public bool IsPlanar
        {
            get
            {
                if (_points.Count < 3)
                {
                    return false;
                }

                List<Line> lines = new List<Line>();
                for (int i = 0; i < _points.Count; i++)
                {
                    Point currentStart = _points[i - 1];
                    Point currentEnd = _points[i];
                    lines.Add(new Line(currentStart, currentEnd));
                }
            }
        }
    }
}
