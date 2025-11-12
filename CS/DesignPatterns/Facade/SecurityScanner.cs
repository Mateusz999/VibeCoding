using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class SecurityScanner
    {
        public IEnumerable<String> SecurityScan(string githubUrl)
        {
            Console.WriteLine("Security Scan");

            return new List<string>() { "securityError1" };
        }
    }
}
