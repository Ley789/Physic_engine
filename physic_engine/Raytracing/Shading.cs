using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Euclidean;
using Object;
namespace Raytracing
{
    class Shading
    {
        public const double ambientCoeff = 0.3f;
        public static Vector ambientColor = new Vector { X = 1, Y = 1, Z = 1 };

        public static Vector AmbientColor()
        {
            return ambientColor * ambientCoeff;
        }

        public static Vector Diffuse(Primitive p, Light l, Vector it)
        {
            var ld = (l.position - it).Normalize();
            return l.lightColor * p.diffuse * Math.Max(0, ld.ScalarProduct(p.NormalVector(it)));
        }

        public static Vector Spec(Primitive p, Light l, Vector it, Ray r)
        {
            var ld = (l.position - it).Normalize();
            var h = Math.Max(0, ((-r.Direction).Normalize() + ld).Normalize().ScalarProduct(p.NormalVector(it)));
            return l.lightColor * p.spec * Math.Pow(h, p.rough);
        }
    }
}
