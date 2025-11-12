using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class ReportGenerator
    {
        public void GenerateReport(IEnumerable<string>qualityScanErrors, IEnumerable<string> securityScanErrors, IEnumerable<string> dependencyScanErrors)
        {
            Console.WriteLine("Quality scan erros: ");
            Console.WriteLine(string.Join(",",qualityScanErrors));

            Console.WriteLine("Security scan erros: ");
            Console.WriteLine(string.Join(",", securityScanErrors));

            Console.WriteLine("Dependency scan erros: ");
            Console.WriteLine(string.Join(",", dependencyScanErrors));
        }
    }
}
