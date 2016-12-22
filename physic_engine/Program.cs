using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;
using Object;
using Raytracing;
using System.Windows.Forms;

namespace physic_engine
{
    class Program
    {
        //intervall in ms
        public static double time_intervall = 50;
        public static int interval = 500;
        static void Main(string[] args)
        {

            var s = new Space(200, 200);
            var sp = new Sphere();
            var sp2 = new Sphere();
            var rP = new Plane(new Vector { X = 1, Y = 0, Z = 0 }, new Vector { X = 1, Y = 0, Z = 0 });
            var lP = new Plane(new Vector { X = -8, Y = 0, Z = 0 }, new Vector { X = -1, Y = 0, Z = 0 });
            var backP = new Plane(new Vector { X = 0, Y = 0, Z = 8 }, new Vector { X = 0, Y = 0, Z = 1 });
            var fP = new Plane(new Vector { X = 0, Y = 0, Z = -11 }, new Vector { X = 0, Y = 0, Z = -1 });
            var tP = new Plane(new Vector { X = 0, Y = 8, Z = 0 }, new Vector { X = 0, Y = 1, Z = 0 });
            var botP = new Plane(new Vector { X = 0, Y = -8, Z = 0 }, new Vector { X = 0, Y = -1, Z = 0 });
         //  s.primList.Add(rP);
         //   s.primList.Add(lP);

            sp.velocity.X = 1;
            sp.velocity.Y = 1;
            sp.position.X = -5;
            sp.position.Y = -5;
            sp2.velocity.X = 1;
            sp2.position.X = -5;
            s.primList.Add(sp);
            s.primList.Add(sp2);
            var f = new Form();
            var c = new Raytracing.Camera();
            f.Size = new System.Drawing.Size(200, 200 + 35);
            f.Show();
            f.FormBorderStyle = FormBorderStyle.None;

            for (var i = 0; i < interval; i++)
            {
                s.Simulate(time_intervall);
                s.RenderImage(c, f);
                //System.Threading.Thread.Sleep((int)time_intervall);
            }

            Console.ReadLine();

        }
    }
}
