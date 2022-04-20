using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathLibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector a1 = new Vector(1, 1, 1);
            Vector a2 = new Vector(1, 1, 1);
            Vector a3 = new Vector(1, 1, 1);
            Vector b1 = new Vector(1, 1, 1);
            Vector b = new Vector(1, 1, 1);
            Vector c = b.Subtract(a1, a2, a3, b1);
            Console.WriteLine($"c: '{c}'");
        }
    }
}
