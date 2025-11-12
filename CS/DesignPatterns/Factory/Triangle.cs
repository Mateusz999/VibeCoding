using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Triangle : Shape
    {
        public override void Render()
        {
            Console.WriteLine("Render Triangle");
        }
    }
}
