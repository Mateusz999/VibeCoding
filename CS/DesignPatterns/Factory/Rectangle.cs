using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Rectangle : Shape
    {
        public override void Render()
        {
            Console.WriteLine("Render Rectangle");
        }
    }
}
