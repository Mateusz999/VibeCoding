using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculations
{
    public static class LinearAlgebra
    {
        public static long[] vector_a;
        public static long[] vector_b;
        public static long scalarProductSeq = 0;
        public static long scalarProductPar = 0;

        private static void generateVector(long size)
        {
            vector_a = new long[size];
            vector_b = new long[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                vector_a[i] = random.Next(0, 10);
                vector_b[i] = random.Next(0, 10);
            }
        }


// ---- MNOŻENIE MACIERZY PRZEZ WEKTOR

        public static void matrixVectorMultiplication()
        {
            Console.Write("Input vectors size: ");
            long size = int.Parse(Console.ReadLine());
            generateVector(size);
        }

        private static void matrixVectorMultiplicationSequential(long size)
        {

        }



        // ---- MNOŻENIE WEKTORA PRZEZ WEKTOR
        public static void vectorVectorScalar()
        {
            Console.Write("Input vectors size: ");
            long size = int.Parse(Console.ReadLine());
            generateVector(size);
            int threadBase = 2;
            for(int i = 1;i<=10;i++)
            {   
                scalarProductOfVectorsParallel((int)Math.Pow(threadBase,i));
            }
            scalarProductOfVectorsSequential();
        }
        private static void scalarProductOfVectorsSequential()
        {
            Stopwatch stopwatch = new();

            stopwatch.Restart();

                for (int i = 0; i < vector_a.Length; i++)
                {
                    scalarProductSeq += vector_a[i] * vector_b[i];
                }
            
            stopwatch.Stop();
            Console.WriteLine($"Scalar product of vector for Sequential: {scalarProductSeq} Time: {stopwatch.ElapsedTicks}");
        }

        private static void scalarProductOfVectorsParallel(int threads)
        {
            scalarProductPar = 0;
            Stopwatch stopwatch = new();

            var opt = new ParallelOptions()
            {
                MaxDegreeOfParallelism = threads
            };

            double avg = 0.0;
            for(int i=0;i<100;i++)
            {
                stopwatch.Restart();

                Parallel.For<long>(
                0,
                vector_a.Length,
                opt,
                () => 0,
                (i, state, localSum) =>
                {
                    return localSum + vector_a[i] * vector_b[i];
                },
                localSum =>
                {
                    Interlocked.Add(ref scalarProductPar, localSum);
                });

                stopwatch.Stop();
                avg += stopwatch.ElapsedTicks;
            }
            
            Console.WriteLine($"Scalar product of vector for Parallel: {scalarProductPar} Time: {avg/100} Threads: {  threads}");
        }


    }
}
