using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryLibrary;
using MathLibrary;

namespace GeometryLibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p0 = new Point();
            Point p1 = new Point(100, 0, 0);
            Point p2 = new Point(100, 200, 0);
            Point p3 = new Point(100, 400, 0);
            Point p4 = new Point(0, 600, 0);
            Point p5 = new Point(0, 400, 0);
            Point p6 = new Point(0, 200, 0);
            List<Point> points = new List<Point>();
            points.Add(p0);
            points.Add(p1);
            points.Add(p2);
            points.Add(p0);
            Polyline line = new Polyline(points.ToArray());

            Console.WriteLine(line.Area);
        }
    }
}
