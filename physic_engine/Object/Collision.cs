using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;

namespace Object
{
    class CollisionDetection
    {
        //TODO normalize maybe or check physic book and return the force vector
        public static Vector? Collision(Sphere f, Sphere s)
        {
            var diff = s.position - f.position;
            if (diff.EuclideanNorm() <= s.Radius + f.Radius)
            {
                return diff;
            }
            return null;
        }
        public static Vector? Collision(Sphere f, Plane s)
        {
            return null;
        }
        public static Vector? Collision(Plane f, Sphere s)
        {
            return Collision(s,f);
        }
        public static Vector? Collision(Plane f, Plane s)
        {
            return null;
        }
    }
}
