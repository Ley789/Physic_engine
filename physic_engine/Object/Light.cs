using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euclidean;
using System.Drawing;

namespace Object
{ 
    class Light
    {
        public Vector lightColor;
        public Vector position;
        public LightType type;

    }
    
    enum LightType
    {
        Pointlight,
    }
}
