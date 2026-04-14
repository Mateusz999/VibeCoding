using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    public static class StringMethods
    {

        static private string berlin = "berlin";
        static private string berli = "berli";
        static private string berl = "berl";

        static private  string test = "abccbaaabbccccbbaa";

        /// <summary>
        /// Metoda wypisująca porównanie ciągi tekstu, biorąc pod uwage kolejność leksykograficzną,
        /// zwracana wartość do  -1,0,1
        /// </summary>
        public static void printLexicographic()
        {
            Console.WriteLine(berlin.CompareTo(berli));
            Console.WriteLine(berli.CompareTo(berlin));
            Console.WriteLine(berlin.CompareTo(berlin));
        }

        public static void printStrinMethod()
        {
            Console.WriteLine(test.IndexOf('a'));
            Console.WriteLine(test.LastIndexOf('a'));

            Console.WriteLine(test.Contains("bbccc"));

            Console.WriteLine(test.StartsWith("abc"));
            Console.WriteLine(test.EndsWith("aa"));

            Console.WriteLine(test.Substring(2, 7));
        }

    }
}
