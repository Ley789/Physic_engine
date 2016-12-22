using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidean
{
    struct Vector
    {
        public double X;
        public double Y;
        public double Z;
        
        #region vector arithmetic

        public static Vector operator +(Vector v, double value)
        {
            Vector a;
            a.X = v.X + value;
            a.Y = v.Y + value;
            a.Z = v.Z + value;
            return a;
        }

        public static Vector operator +(Vector v, Vector s)
        {
            Vector a;
            a.X = v.X + s.X;
            a.Y = v.Y + s.Y;
            a.Z = v.Z + s.Z;
            return a;
        }

        public static Vector operator -(Vector v, double value)
        {
            Vector a;
            a.X = v.X - value;
            a.Y = v.Y - value;
            a.Z = v.Z - value;
            return a;
        }
        public static Vector operator -(Vector v, Vector s)
        {
            Vector a;
            a.X = v.X - s.X;
            a.Y = v.Y - s.Y;
            a.Z = v.Z - s.Z;
            return a;
        }
        
        public static Vector operator *(Vector v, double value)
        {
            Vector a;
            a.X = v.X * value;
            a.Y = v.Y * value;
            a.Z = v.Z * value;
            return a;
        }
        public static Vector operator *( double value, Vector v)
        {
            Vector a;
            a.X = v.X * value;
            a.Y = v.Y * value;
            a.Z = v.Z * value;
            return a;
        }

        //TODO check componentwise multiplication definition
        public static Vector operator *(Vector v, Vector s)
        {
            Vector a;
            a.X = v.X * s.X;
            a.Y = v.Y * s.Y;
            a.Z = v.Z * s.Z;
            return a;
        }

        public static Vector operator /(Vector v, double value)
        {
            Vector a;
            var n = 1 / value;
            a.X = v.X * n;
            a.Y = v.Y * n;
            a.Z = v.Z * n;
            return a;
        }
        //TODO check componentwise division definition
        public static Vector operator /(Vector v, Vector s)
        {
            Vector a;
            a.X = v.X / s.X;
            a.Y = v.Y / s.Y;
            a.Z = v.Z / s.Z;
            return a;
        }

        public static Vector operator -(Vector v)
        {
            Vector a;
            a.X = -v.X;
            a.Y = -v.Y;
            a.Z = -v.Z;
            return a;
        }
        public Vector Negate()
        {
            Vector a;
            a.X = -this.X;
            a.Y = -this.Y;
            a.Z = -this.Z;
            return a;
        }

        public double ScalarProduct()
        {
            return ScalarProduct(this);
        }

        public double ScalarProduct(Vector s)
        {
            double res = 0;
            res += this.X * s.X + this.Y * s.Y + this.Z * s.Z;
            return res;
        }

        public double EuclideanNorm()
        {
            return Math.Sqrt(this.ScalarProduct());
        }
        public Vector Normalize()
        {
            return this / this.EuclideanNorm();
        }

        public double Min_Positive()
        {
            double res = this.X;
            if(this.Y >= 0) res = Math.Min(res, this.Y);
            if (this.Z >= 0) res = Math.Min(res, this.Z);
            return res;
        }
        #endregion

        public override String ToString()
        {
            return this.X + " " + this.Y + " " + this.Z;
        }

    }
}
