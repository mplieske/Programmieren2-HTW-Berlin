using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace GeometryLibrary
{
    public class Polyline : Curve, ISurface
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
                if (!IsValid)
                {
                    return false;
                }

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

                List<Vector> vectors = new List<Vector>();
                for (int i = 1; i < _points.Count; i++)
                {
                    Point currentStart = _points[i - 1];
                    Point currentEnd = _points[i];
                    vectors.Add(CreateVectorBetweenPoints(currentStart, currentEnd));
                }

                List<Vector> crossProducts = new List<Vector>();
                for (int i = 1; i < vectors.Count; i++)
                {
                    Vector currentCrossProduct = vectors[0].CrossProduct(vectors[i]);
                    crossProducts.Add(currentCrossProduct);
                }

                bool allCrossProductsCollinear = true;
                for (int i = 1; i < crossProducts.Count; i++)
                {
                    if (!crossProducts[0].AreCollinear(crossProducts[i]))
                    {
                        allCrossProductsCollinear = false;
                        break;
                    }
                }

                return allCrossProductsCollinear;
            }
        }
        public bool IsValid { get { return _points.Count >= 2; } }

        public double Area
        {
            get
            {
                if (!IsClosed || !IsPlanar)
                {
                    Console.WriteLine($"Area: Not closed or not planar. IsPlanar: '{IsPlanar}'; IsClosed: '{IsClosed}'");
                    return 0;
                }
                Console.WriteLine("Area: Is Planar and Closed :)");


                List<Vector> vectors = new List<Vector>();
                for (int i = 1; i < _points.Count; i++)
                {
                    vectors.Add(CreateVectorBetweenPoints(_points[i - 1], _points[i]));
                }
                Console.WriteLine($"Vector Count: '{vectors.Count}'");

                Vector sumOfCrossProducts = Vector.Zero;
                for (int i = 0; i < vectors.Count; i++)
                {
                    Vector vectorI = vectors[i];
                    Vector vectorIPlusOne;
                    vectorIPlusOne = i + 1 == vectors.Count ? vectors[0] : vectors[i + 1];

                    Console.WriteLine($"vectorI: '{vectorI}'; vectorIPlusOne: '{vectorIPlusOne}'");

                    Console.WriteLine($"Crossproduct of '{i}' and '{i + 1}' = '{vectorI.CrossProduct(vectorIPlusOne)}'");

                    sumOfCrossProducts = sumOfCrossProducts.Add(vectorI.CrossProduct(vectorIPlusOne));
                    Console.WriteLine($"Sum of Crossproducts: '{sumOfCrossProducts}'");
                }


                Vector normalVector = vectors[0].CrossProduct(vectors[1]).Normalize();
                Console.WriteLine($"Normalized normal vector: '{normalVector}'");

                double area = sumOfCrossProducts.DotProduct(normalVector) / 2;
                Console.WriteLine($"area: '{area}'");

                return Math.Abs(area);
            }
        }

        public Polyline(Point[] points)
        {
            _points.AddRange(points);
        }

        public void AddPoint(Point newPoint)
        {
            _points.Add(newPoint);
        }

        public void InsertPoint(int index, Point newPoint)
        {
            _points.Insert(index, newPoint);
        }

        public void RemovePoint(int index)
        {
            _points.RemoveAt(index);
        }

        private Vector CreateVectorBetweenPoints(Point startPoint, Point endPoint)
        {
            double deltaX = endPoint.X - startPoint.X;
            double deltaY = endPoint.Y - startPoint.Y;
            double deltaZ = endPoint.Z - startPoint.Z;
            return new Vector(deltaX, deltaY, deltaZ);
        }
    }
}
