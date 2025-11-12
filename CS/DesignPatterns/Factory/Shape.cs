using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public abstract class Shape
    {
        public int x { get; set; }
        public int y { get; set; }

        public abstract void Render();
    }
}
