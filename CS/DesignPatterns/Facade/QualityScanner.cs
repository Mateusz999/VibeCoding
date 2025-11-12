using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class QualityScanner
    {
        public IEnumerable<string> QualityScan(String githubUrl)
        {
            Console.WriteLine("Quality Scan");
            return new List<string>() { "error1", "erro1" };
        }
    }
}
