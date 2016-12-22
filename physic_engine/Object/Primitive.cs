using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raytracing;
using Euclidean;

namespace Object
{
    abstract class Primitive
    {
        // collision detection, returns null if the objects do not collide
        public abstract Vector? Collision(Primitive p);
        public abstract Vector? Collision(Sphere p);
        public abstract Vector? Collision(Plane p);
        // normal vector
        public abstract Vector NormalVector(Vector ip);
        // ray intersection
        //returns a negative number if the ray does not intersect with the object
        public abstract double Ray_Intersection(Ray r);



        // Material
        public Vector color = new Vector { X = 0, Y = 1, Z = 0 };
        public double diffuse = 0.5;
        public double spec = 0.5;
        public double rough = 50;
        // position in space
        public Vector position = new Vector();
        //time in ms
        public virtual void Update_Position(double time)
        {
            position = position + velocity * (time / 1000);
        }
        // velocity in m/s
        public Vector velocity = new Vector();
        public Vector angle_Velocity = new Vector();
        // weight
        double Weight { get; set; }
    }
}
