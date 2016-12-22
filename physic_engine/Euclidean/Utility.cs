using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidean
{
    class Utility
    {
        //if the value of the square root is smaller than 0 then the function will return null
        //Change return type
        public static Vector? Quadratic_Equation(double a, double b, double c)
        {
            var res = new Vector();
            res.Z = -1;

            double toSquare = b * b - 4 * a * c;
            if (toSquare < 0) return null;
            var square = Math.Sqrt(toSquare);
            var q = 2 * a;
            res.X = ((-b) + square) / q;
            res.Y = ((-b) - square) / q;
            return res;
        }
    }
}
