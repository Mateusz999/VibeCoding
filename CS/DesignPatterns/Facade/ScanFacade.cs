using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class ScanFacade
    {
        private QualityScanner _qualityScanner = new QualityScanner();
        private SecurityScanner _securityScanner = new SecurityScanner();
        private DependencyScaner _dependencyScaner = new DependencyScaner();
        private ReportGenerator _reportGenerator = new ReportGenerator();
   
        public void Scan(string githubUrl)
        {

            Console.WriteLine($"Scanning {githubUrl}");
            var qualityErrors = _qualityScanner.QualityScan(githubUrl);
            var securityErrors = _securityScanner.SecurityScan(githubUrl);
            var dependencyErrors = _dependencyScaner.DependencyScan(githubUrl);

            Console.WriteLine("Scan report: ");
            _reportGenerator.GenerateReport(qualityErrors, securityErrors, dependencyErrors);
        }
    }
}
