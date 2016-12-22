using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object;
using Raytracing;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace Euclidean
{
    class Space
    {
        public List<Primitive> primList = new List<Primitive>();
        //setter acces via enumerate TODO
        public Ray[][] Perspective = null;
        public int width;
        public int height;
        public DirectBitmap img;
        public bool shade = true;
        public Light light = new Light();
        public Space()
        {
            width = 250;
            height = 250;
            img = new DirectBitmap(width, height);
            light.position = new Vector { X = 0, Y = 0, Z = -5 };
            light.lightColor = new Vector { X = 1, Y = 1, Z = 1 };
        }
        public Space(int x, int y)
        {
            width = x;
            height = y;
            img = new DirectBitmap(width, height);
            light.position = new Vector { X = 0, Y = 0, Z = -5 };
            light.lightColor = new Vector { X = 1, Y = 1, Z = 1 };
        }

        //time in s
        public void Simulate(double time)
        {
            Vector? res = null;
            for(int i = 0; i < primList.Count; i++)
            {
                primList[i].Update_Position(time);
            }
            for (int i = 0; i < primList.Count; i++)
            {
                for (int j = i + 1; j < primList.Count; j++)
                {
                    res = primList[i].Collision(primList[j]);
                    if(res.HasValue)
                    {
                        var norm = res.Value.Normalize();
                        var change = primList[i].velocity.EuclideanNorm() * norm;
                        var change2 = primList[j].velocity.EuclideanNorm() * norm;
                        primList[i].velocity -= change;
                        primList[j].velocity += change2;
                        primList[i].Update_Position(time);
                        primList[j].Update_Position(time);
                    }
                }
            }
        }

        #region render
        //Render to debug, outsource this code later
        public Bitmap RenderImage(Camera c, Form f)
        {
            if(Perspective == null)
            {
                //TODO change, camera changed would not affect this -> not correct
                Perspective = Perspective_Projection(width, height, c);
            }
            var l = Perspective;
            var sp = new Stopwatch();
            sp.Start();
            for (var i = 0; i < l.Length; i++){
                for(var j = 0; j < l[i].Length; j++){
                    //get closest primitve if it exists
                    Primitive o;
                    var res = Closest_Primitive(l[i][j], out o);
                    if (res > 0 && shade)
                    {
                        var ca = Shading.AmbientColor();
                        var cd = Shading.Diffuse(o, light, l[i][j].IntersectionPoint(res));
                        var cs = Shading.Spec(o, light, l[i][j].IntersectionPoint(res), l[i][j]);
                        var finalC = (o.color * (ca + cd + cs)) * 255;
                        finalC.X = Math.Max(0, Math.Min(255, finalC.X));
                        finalC.Y = Math.Max(0, Math.Min(255, finalC.Y));
                        finalC.Z = Math.Max(0, Math.Min(255, finalC.Z));
                        img.Bits[i * height + j] = System.Drawing.Color.FromArgb((int) finalC.X, (int) finalC.Y, (int)finalC.Z).ToArgb();
                    }
                    else
                    {
                        img.Bits[i * height + j] = Color(res).ToArgb();
                    }
                }
            }
            sp.Stop();
            var ts = sp.ElapsedMilliseconds;
            Console.WriteLine("Time in ms " + ts);
            f.CreateGraphics().DrawImage(img.Bitmap, 0, 0);
            return img.Bitmap;
        }

        private double Closest_Primitive(Ray r, out Primitive o)
        {
            double res = -1;
            double tmp = -1;
            o = null;
            foreach(var p in primList)
            {
                tmp = Min_Positive(res, p.Ray_Intersection(r));
                if(tmp != res && tmp > 0)
                {
                    o = p;
                    res = tmp;
                }
            }
            return res;
        }

        private Ray[][] Perspective_Projection(int width, int heigh, Camera c)
        {
            var rays = new Ray[heigh][];
            for (var i = 0; i < heigh; i++)
            {
                rays[i] = new Ray[width];
                for(var j = 0; j < width; j++)
                {
                  rays[i][j] = new Ray(c.Position, Perspective_Direction(Scale(i, heigh), Scale(j, width), c));
                }
            }
            return rays;
        }

        private Vector Perspective_Direction(double upFactor, double rightFactor, Camera c)
        {
            return c.Forward + c.Right * rightFactor + c.Up * (-upFactor);
        }

        // Scales a intervall from [0, X] to [-0.5, 0.5]
        private double Scale(double val, double max)
        {
            return (val / max) - 0.5;
        }
        //provisorisch, 1 = rot; 0 = schwarz
        private Color Color(double v)
        {
            if (v < 0) return System.Drawing.Color.FromArgb(0, 0, 0);
            return System.Drawing.Color.FromArgb(255,0,0);
        }
        private double Min_Positive(double x, double y)
        {
            if (x < 0) return y;
            if (y < 0) return x;
            return Math.Min(x, y);
        }
        #endregion
    }
}
