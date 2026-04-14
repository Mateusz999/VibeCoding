using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculations
{
    
    public static class PiCalculation
    {
        static Stopwatch _stopwatch = new Stopwatch();

        public static int CalculatePiSequential(int amount, out double pi)
        {
            int inside = 0;
            Random rnd = new Random();

            for (int i = 0; i < amount; i++)
            {
                double x = rnd.NextDouble();
                double y = rnd.NextDouble();

                if (x * x + y * y <= 1)
                    inside++;
            }

            pi = 4.0 * inside / amount;
            return inside;
        }

        public static int CalculatePiParallel(int amount, out double pi)
        {
            int logicalCores = Environment.ProcessorCount;
            int chunk = amount / logicalCores;

            int[] results = new int[logicalCores];

            Parallel.For(0, logicalCores, core =>
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                int localInside = 0;

                for (int i = 0; i < chunk; i++)
                {
                    double x = rnd.NextDouble();
                    double y = rnd.NextDouble();

                    if (x * x + y * y <= 1)
                        localInside++;
                }

                results[core] = localInside;
            });

            int inside = results.Sum();
            pi = 4.0 * inside / amount;
            return inside;
        }
        public static double CalculatedefiniteIntegralByRectangleMethodSequential(int amountOfSteps)
        {
            double leftPoint = -1.0;
            double rightPoint = 1.0;
            double dx = (rightPoint - leftPoint) / amountOfSteps;
            double sumRectangleArea = 0.0;

            while(leftPoint <  rightPoint)
            {
                sumRectangleArea += Math.Sqrt(1 - Math.Pow(leftPoint, 2)) * dx;
                leftPoint += dx;

            }
            double TwoPi = 2 * sumRectangleArea;
            return TwoPi;
        }

        public static double CalculatedefiniteIntegralByRectangleMethodParallelByLock(int amountOfSteps)
        {
            double dx = 2.0 / amountOfSteps;
            double sumRectangleArea = 0.0;
            object locker = new object();

            Parallel.For(0, amountOfSteps, i =>
            {
                double x = -1.0 + i * dx;
                double local = Math.Sqrt(1 - x * x) * dx;

                lock(locker)
                {
                    sumRectangleArea += local;
                }
            });
            return 2 * sumRectangleArea;
        }

        public static double CalculatedefiniteIntegralByRectangleMethodParallel(int amountOfSteps)
        {
            double dx = 2.0 / amountOfSteps;
            double globalSum = 0.0;

            Parallel.For<double>(
                0,
                amountOfSteps,
                () => 0.0,
                (i, state, localSum) =>
                {
                    double x = -1.0 + i * dx;
                    localSum += Math.Sqrt(1 - x * x) * dx;
                    return localSum;
                },

                localSum =>
                {
                    double initial, computed;
                    do
                    {
                        initial = globalSum;
                        computed = initial + localSum;
                    }
                    while (Interlocked.CompareExchange(ref globalSum, computed, initial) != initial);
                });
            return 2 * globalSum;
        }

        public static double CalculateDefiniteIntegralByTrapezoidSequential(int amountOfSteps)
        {
            double left = -1.0;
            double right = 1.0;
            double sumTrapezoidArea = 0.0;
            double dx = (right - left) / amountOfSteps;

            for (int i = 0; i < amountOfSteps; i++)
            {
                double x1 = left + i * dx;
                double x2 = x1 +  dx;
                double y1 = Math.Sqrt(1 - Math.Pow(x1, 2));
                double y2 = Math.Sqrt(1  - Math.Pow(x2, 2));

                sumTrapezoidArea += (y1 + y2) / 2 * dx;
            }
            return sumTrapezoidArea*2;
        }
/*        public static double SimsponParallel(int amountOfSteps)
        {
            double a = -1.0;
            double b = 1.0;
            double h = (b - a) / amountOfSteps;

            double sum = Math.Sqrt(1 - a * a) + Math.Sqrt(1 - b * b);

            Parallel.For<double>(
                0,
                amountOfSteps,
                ()=> 0.0,
                   (i, state, localSum) =>
                   {
                       double x1 = -1.0 + i * dx;
                       double x2 = x1 + dx;
                       double y1 = Math.Sqrt(1 - Math.Pow(x1, 2));
                       double y2 = Math.Sqrt(1 - Math.Pow(x2, 2));

                       localSum += (y1 + y2) / 2 * dx;
                       return localSum;
                   },

                localSum =>
                {
                    double initial, computed;
                    do
                    {
                        initial = globalSum;
                        computed = initial + localSum;
                    }
                    while (Interlocked.CompareExchange(ref globalSum, computed, initial) != initial);
                })

               );

        }*/

        public static double SimpsonSequential(int n)
        {
            double a = -1.0;
            double b = 1.0;
            double h = (b - a) / n;

            double sum = Math.Sqrt(1 - a * a) + Math.Sqrt(1 - b * b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                double fx = Math.Sqrt(1 - x * x);

                if (i % 2 == 0)
                    sum += 2 * fx;
                else
                    sum += 4 * fx;
            }
            return (h / 3.0) * sum * 2;
        }


        public static double CalculateDefiniteIntegralByTrapezoidParallel(int amountOfSteps)
        {
            double dx = 2.0 / amountOfSteps;
            double globalSum = 0.0;

            Parallel.For<double>(
                0,
                amountOfSteps,
                () => 0.0,
                (i, state, localSum) =>
                {
                    double x1 = -1.0 + i * dx;
                    double x2 = x1 + dx;
                    double y1 = Math.Sqrt(1 - Math.Pow(x1, 2));
                    double y2 = Math.Sqrt(1 - Math.Pow(x2, 2));

                    localSum += (y1 + y2) / 2 * dx;
                    return localSum;
                },

                localSum =>
                {
                    double initial, computed;
                    do
                    {
                        initial = globalSum;
                        computed = initial + localSum;
                    }
                    while (Interlocked.CompareExchange(ref globalSum, computed, initial) != initial);
                });
            return 2 * globalSum;
        }
        
    


        public static void definiteIntegralByRectangleMethod()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Definite Integral Pi");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter amount of steps:  ");
            int.TryParse(Console.ReadLine(), out int amountOfSteps);
            _stopwatch.Restart();
            double sequentialPi = CalculatedefiniteIntegralByRectangleMethodSequential(amountOfSteps);
            _stopwatch.Stop();
            Console.WriteLine($"Rectangle Sequential Pi: {sequentialPi} Time: {_stopwatch.ElapsedMilliseconds} Diff: {Math.Abs(Math.PI - sequentialPi )}");
            _stopwatch.Restart();
            double parallelPiWithLock = CalculatedefiniteIntegralByRectangleMethodParallelByLock(amountOfSteps);
            _stopwatch.Stop();
            Console.WriteLine($"Rectangle Parallel Pi with lock: {parallelPiWithLock} Time: {_stopwatch.ElapsedMilliseconds} Diff: {Math.Abs(Math.PI - parallelPiWithLock)}");

            _stopwatch.Restart();
            double parallelPi = CalculatedefiniteIntegralByRectangleMethodParallel(amountOfSteps);
            _stopwatch.Stop();
            Console.WriteLine($"Rectangle Parallel Pi : {parallelPi} Time: {_stopwatch.ElapsedMilliseconds} Diff: {Math.Abs(Math.PI - parallelPi)}");


            
            _stopwatch.Restart();
            double sequentialTrapezoid = CalculateDefiniteIntegralByTrapezoidSequential(amountOfSteps);
            _stopwatch.Stop();
            Console.WriteLine($"Trapezoid Sequential  Pi : {sequentialTrapezoid} Time: {_stopwatch.ElapsedMilliseconds} Diff: {Math.Abs(Math.PI - sequentialTrapezoid)}");


            _stopwatch.Restart();
            double parallelTrapezoid = CalculateDefiniteIntegralByTrapezoidParallel(amountOfSteps);
            _stopwatch.Stop();
            Console.WriteLine($"Trapezoid Parallel  Pi : {parallelTrapezoid} Time: {_stopwatch.ElapsedMilliseconds} Diff: {Math.Abs(Math.PI - parallelTrapezoid)}");

            _stopwatch.Restart();
            double SimpsonSequential_ = SimpsonSequential(amountOfSteps);
            _stopwatch.Stop();
            Console.WriteLine($"Simpson sequential  Pi : {SimpsonSequential_} Time: {_stopwatch.ElapsedMilliseconds} Diff: {Math.Abs(Math.PI - SimpsonSequential_)}");



        }

        public static void monteCarlo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Monte Carlo");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter amount of dots to generate: ");
            int.TryParse(Console.ReadLine(), out int dotsToGenerate);
            Console.WriteLine();
            Console.WriteLine();
            _stopwatch.Restart();
            int sequentialInside = PiCalculation.CalculatePiSequential(dotsToGenerate, out double calculationPiBySequentional);
            _stopwatch.Stop();
            Console.WriteLine($"Sequentional Pi: {(sequentialInside / (double)dotsToGenerate) * 4} Time: {_stopwatch.ElapsedMilliseconds} ms. Diff : {Math.PI - (sequentialInside / (double)dotsToGenerate) * 4}");
            _stopwatch.Restart();
            int parallerInside = PiCalculation.CalculatePiParallel(dotsToGenerate, out double calculatedPiByParallel);
            _stopwatch.Stop();
            Console.WriteLine($"Paraller Pi: {(parallerInside / (double)dotsToGenerate) * 4} Time: {_stopwatch.ElapsedMilliseconds} ms. Diff: {Math.PI - (parallerInside / (double)dotsToGenerate) * 4}");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
