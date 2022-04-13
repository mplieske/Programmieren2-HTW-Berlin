using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Vector : PointVectorBase
    {
        public Vector(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector sourceVector)
        {
            X = sourceVector.X;
            Y = sourceVector.Y;
            Z = sourceVector.Z;
        }

        public Vector Add(params Vector[] addends)
        {
            return CalculateSum(addends).AsVector();
        }

        public Vector Subtract(params Vector[] subtrahends)
        {
            Vector firstSubtrahend = new Vector(subtrahends[0]);

            for (int i = 1; i < subtrahends.Length; i++)
            {
                firstSubtrahend.X -= subtrahends[i].X;
                firstSubtrahend.Y -= subtrahends[i].Y;
                firstSubtrahend.Z -= subtrahends[i].Z;
            }

            return firstSubtrahend;
        }
    }
}
