using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    public static class LP1
    {
        static short a = 12;
        static short b = 12;

        static byte c = 12;
        static byte d = 12;


        // zmienna typu referencyjnego taka jak string może mieć przypisaną wartość null
        static string e = null;


        // zmienna typu wartościowego domyślnie nie może mieć przypisawej wartości null,
        // jest to natomiast możliwe po uzyciu operatora nullable
        static int? f = null;


        /*
         Typ byte oraz short podczas wykonywania operacji arytmetycznych niejawnie konwertowane są to typu int,
        gdy chcielibysmy przypisać wynik do zmiennej tego samego typu wyświetli nam się błąd, chyba że jawnie przekonwertujemy
        do danego typu
         
         */
         static short shortResult = (short)( a + b);

        static byte byteResult = (byte)(c + d);


        public static void display()
        {
            Console.WriteLine(shortResult.GetType());
            Console.WriteLine(byteResult.GetType());
        }
    }


    public class Person
    {
        public static int Population;
        public string name;
        public Person(string name)
        {
            Population += 1;
            this.name = name;
        }
    }

 
}
