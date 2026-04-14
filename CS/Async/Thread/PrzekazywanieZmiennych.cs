using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    public static class PrzekazywanieZmiennych
    {

        /// <summary>
        /// Statycznia funkcja, dodająca do tekstu fraze " - zmodyfikowana"
        /// </summary>
        /// <param name="text">String Builder</param>
        public static void boo(StringBuilder text)
        {
            text.Append(" - zmodyfikowana.");
            Console.WriteLine($"Zmienna po modyfikacji: {text}");
            text = null;
            Console.WriteLine("Zmienna po wyzerowaniu referencji: "+(text == null));
        }

        /// <summary>
        /// Styatyczna funkcja, która inkrementuje wartość
        /// </summary>
        /// <param name="a">referencja do int</param>
        public static void foo(ref int a)
        {
            a++;
            Console.WriteLine(a);
        }
    }
}
