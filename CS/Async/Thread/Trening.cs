using System.Text;
using System.Threading.Tasks;

public class Trening
{
    static readonly CancellationTokenSource cancellationToken = new();
    static readonly object lockObj = new object();
    static int idx = 0;

    public static async Task Treningowo()
    {
        int counter = 0;

        Task t1 = Task.Run(() => { for (int i = 0; i < 1000; i++) counter++; });
        Task t2 = Task.Run(() => { for (int i = 0; i < 1000; i++) counter++; });

        await Task.WhenAll(t1, t2);
        Console.WriteLine(counter); // może być < 2000!


        Task cancelTask = Task.Run(() =>
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Press enter to cancel ...");
            }

            Console.WriteLine("Enter key pressed: cancelling task");
            cancellationToken.Cancel();
        });

        Task countingTask = counting(cancellationToken.Token);

        Task finishedTasks = await Task.WhenAny(cancelTask, countingTask);

        if (finishedTasks == cancelTask)
        {
            try
            {
                await countingTask;
                Console.WriteLine("Counting completed!");
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Counting has been cancelled.");
            }
        }

        Console.WriteLine("Application ended");
    }

    private static async Task counting(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            await readCounter(i, token);

            await Task.Delay(500, token);
        }
    }

    private static async Task readCounter(int number, CancellationToken token)
    {
        for (int j = 0; j <= number; j++)
        {
            token.ThrowIfCancellationRequested();

            lock (lockObj)
            {

                idx++;
                Console.WriteLine($"Thread: {number} is counting {j} counter of loop: {idx}");
            }

            await Task.Delay(500, token);
        }
    }

    public static void printResult()
    {
        int? typ = 2;
        string kolor = "czerwony";
        string typowanie = typ switch
        {
            1 => "Wygrana",
            2 => "Przegrana",
            _ => "Remis"
        };

        Console.WriteLine(typowanie);

        string wynik = (typ, kolor) switch
        {
            (1, "niebieski") => "Wygrany błękit",
            (2, "czerwony") => "Przegrana czerwień",
            _ => "Bylejaki remis"
        };

        Console.WriteLine(wynik);
    }

}
