using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;

namespace Raytracing
{
    class Ray
    {

        public Vector Position { get; } = new Vector();
        public Vector Direction { get; } = new Vector();

        private int interval_Begin = 0;
        private int interval_End = 1000000;
        public int Interval_Begin
        {
            get
            {
                return interval_Begin;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Start of a ray interval cannot be smaller then 0.");
                interval_Begin = value;
            }
        }
        public int Interval_End
        {
            get
            {
                return interval_End;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Start of a ray interval cannot be smaller then 0.");
                interval_End = value;
            }
        }
        public Ray(Vector p, Vector d)
        {
            Position = p;
            Direction = d;
        }

        public Vector IntersectionPoint(double t)
        {
            return Position + t * Direction;
        }
    }
}
