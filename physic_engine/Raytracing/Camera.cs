using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;

namespace Raytracing
{
    //vectors are all unit vectors
    class Camera
    {
        public Vector Position { get; } = new Vector();
        public Vector Forward { get; } = new Vector();
        public Vector Up { get; } = new Vector();
        public Vector Right { get; } = new Vector();

        public Camera()
        {
            var p = new Vector();
            p.Z = -10;
            Position = p;
            var f = new Vector();
            f.Z = 1;
            Forward = f;
            var up = new Vector();
            up.Y = 1;
            Up = up;
            var right = new Vector();
            right.X = 1;
            Right = right;
        }
    }
}
