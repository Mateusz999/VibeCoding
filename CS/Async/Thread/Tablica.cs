using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    public static class Tablica
    {
        private static int[] tablicaJednowymiarowa = [1, 2, 3, 4, 5];
        private static int[] tablicaJednowymiarowa2 = new int[3];

        private static int[,] tablicaDwuwymiarowa =
        {
            { 1,2,3 },
            {4,5,6 },
            { 7,8,9 }
        };

        public static void printByIndexer()
        {
            for(int i  = 1;i<= tablicaJednowymiarowa.Length; i++)
            {
                Console.WriteLine($"index {tablicaJednowymiarowa.Length - i} wynosi {tablicaJednowymiarowa[^i]}");
            }
        }

        public static int Factorial(int i )
        {
            if (i == 0) return 1;
            return i * Factorial(i - 1);
        }

    }
}
