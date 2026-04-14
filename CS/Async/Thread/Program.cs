using System.Text;
using System.Threading.Tasks;
using Thread;

class Program
{
    public static void Main(string[] Args)
    {

        methodology methodology = new methodology();

        methodology.foo("str");
        methodology.foo(1);
        methodology.foo((byte)2);
        methodology.foo('a');


        Console.WriteLine(methodology.Length);
        Console.WriteLine(methodology.Length.GetType());

        using (var obj = new KonstruktorDestruktor())
        {
        }


    }

    public class KonstruktorDestruktor : IDisposable
    {
        public KonstruktorDestruktor()
        {
            Console.WriteLine("Utworzono instancje");
        }

        public void Dispose()
        {
            Console.WriteLine("Zwolniono zasoby");
            GC.SuppressFinalize(this); 
        }

        ~KonstruktorDestruktor()
        {
            Console.WriteLine("Wyrzucono instancje z pamięci");
        }
    }

    public class methodology
    {
        public void foo(string a) => Console.WriteLine("string");
        public void foo(int a) => Console.WriteLine("integer");
        public void foo(byte a) => Console.WriteLine("byte");
        public void foo(char a) => Console.WriteLine("char");
        public int Length
        {
            get { return 10; }
        }

    }
}
