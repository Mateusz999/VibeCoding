using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InterviewApp
{

    public interface ICalculationService
    {
        BigInteger calculate(BigInteger factorialArgument);
        BigInteger iterationalCalculations(BigInteger factorialArgument);
    }
    public class CalculationService : ICalculationService
    {
        public BigInteger calculate(BigInteger factorialArgument)
        {
            return (factorialArgument == 1 || factorialArgument == 0)
            ? 1
            : factorialArgument * calculate(factorialArgument - 1);
        }

        public BigInteger iterationalCalculations(BigInteger factorialArgument)
        {

            BigInteger res = 1;

            if ( factorialArgument == 1 || factorialArgument == 0)
            {
                return 1;
            }

            for ( int i = 2; i <= factorialArgument; i++)
            {
                res *= i;
            }

            return res;
        }
        
    }
}
