using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    public static class NullCoelescence
    {

        public static void printResult()
        {
            string s1 = null;
            // jeżeli operand z lewej jest null to przypisze z prawe
            string s2 = s1 ?? "nic";

            Console.WriteLine(s2);

            string s3 = s2 ?? "haha";
            Console.WriteLine(s2);
            // jeżeli s1 jest null to przypisze wartosc 
            s1 ??= "teraz nie ma null";

            Console.WriteLine(s1);

            StringBuilder sb = new StringBuilder();
            sb = null;
            // w tym wypadku metoda toString nie rzuci wyjatku
            string s = sb?.ToString();


            Console.WriteLine(s);
            // int? moze przyjąc wartosc null
            int? liczba = null;

            string text = liczba?.ToString() ?? "niestety int jest null";

            Console.WriteLine(text);

            string se = (liczba == null) ? "null" : "nienull";
            Console.WriteLine(se);



        }
    }

    }
