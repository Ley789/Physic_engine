using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;
using Raytracing;
using Object;

namespace Object
{
    class Sphere : Primitive
    {
        public double Radius { get; set; }

        public Sphere()
        {
            Radius = 1;
        }

        //returns a negative value if the ray does not intersect the sphere
        public override double Ray_Intersection(Ray r)
        {
            Vector diff = r.Position - this.position;
            double a = r.Direction.ScalarProduct();
            double b = 2 * r.Direction.ScalarProduct(diff);
            double c = diff.ScalarProduct() - Radius * Radius;
            var res = Utility.Quadratic_Equation(a, b, c);
            //TODO make this part better!
            if( res.HasValue)
            {
                return res.Value.Min_Positive();
            }
            return -1;
        }

        //Visitor pattern (multiple dispatch) allows polymorphic call off argument Primitive
        public override Vector? Collision(Primitive p)
        {
            //compile knows that "this" is a sphere so it will call the Collision
            //function of the sphere instead of the function defined in the interface
            return -p.Collision(this);
        } 

        //TODO normalize maybe or check physic book and return the force vector
        public override Vector? Collision (Sphere p)
        {
            var diff = p.position - this.position;
            if(diff.EuclideanNorm() <= p.Radius + this.Radius)
            {
                return diff;
            }
            return null;
        }
        //TODO correct the force direction it could be -p.normal
        public override Vector? Collision(Plane p)
        {
            double coef = (this.position - p.position).ScalarProduct(p.normal);
            if(Math.Abs(coef) > this.Radius)
            {
                return null;
            }
            return p.normal;
        }

        //Convention, ip must be a point on the surface of the sphere
        public override Vector NormalVector(Vector ip)
        {
            return (ip - this.position).Normalize();
        }
    }
}
