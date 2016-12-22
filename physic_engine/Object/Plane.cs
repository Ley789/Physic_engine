using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;
using Raytracing;

namespace Object
{
    class Plane : Primitive
    {
        //normal vector to the plane
        public Vector normal { get; }
        //storing for calculation in plane point distance
        private double normalProduct;

        public Plane(Vector p, Vector n)
        {
            if (n.ScalarProduct(n) == 0) throw new ArgumentException("Normal vector to plane cannot be the 0 vector!");
            position = p;
            normal = n;
            normalProduct = n.ScalarProduct();
        }

        public override Vector? Collision(Primitive p)
        {

            return -p.Collision(this);
        }

        public override Vector? Collision(Sphere p)
        {
            return -p.Collision(this);
        }
        
        //Convention is that planes do not collide, they can overlap
        public override Vector? Collision(Plane p)
        {
            return null;
        }
  
        //Check the direction of the normal vector
        public override Vector NormalVector(Vector ip)
        {
            return normal;
        }

        public override double Ray_Intersection(Ray r)
        {
            var n = normal.ScalarProduct(r.Direction);
            if (n != 0)
            {
                return normal.ScalarProduct(this.position - r.Position) / n;
            }
            return -1;
        }

        public double PlanePointDistance(Vector point)
        {
            return (point - this.position).ScalarProduct(normal) / normalProduct; 
        }
    }
}
