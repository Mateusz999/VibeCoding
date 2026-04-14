using PiCalculations;
using System.Diagnostics;

public class Program
{
    static Stopwatch _stopwatch = new Stopwatch();

    static void Main(String[] args)
    {

        while (true)
        {

          int exerciseToShow = 0;

         displayListOfExercise();

         Console.Write("Which one exercise would you like to choose ? ");

        string parsingStatusUserMessage = int.TryParse(Console.ReadLine(), out exerciseToShow) 
                   ? exerciseToShow > 0 
                        ? "Error 03 - Number of exercise out of the range." 
                        : exerciseToShow.ToString() 
                   : "Error 02 - Incorrect signs as a input.";

            Console.Clear();

           if (exerciseToShow > 9 || exerciseToShow == 0){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(parsingStatusUserMessage);
                Console.ForegroundColor = ConsoleColor.White;
            }
           else
            {
                switch ((Exercise)exerciseToShow)
                {
                    case Exercise.Monte_Carlo_Pi:
                        PiCalculation.monteCarlo();
                        break;
                    case Exercise.Definite_Integral_Pi:
                        PiCalculation.definiteIntegralByRectangleMethod();
                        break;
                    case Exercise.Scalar_Product_Of_Vectors:
                        LinearAlgebra.vectorVectorScalar();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error 01 - Solution for this exercise doesn't exist yet.");
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                }
                
            }
        }
    }

    private static void displayListOfExercise()
    {
        Exercise exercises = new();
        Array exe = Enum.GetValues(typeof(Exercise));
        Console.WriteLine("No.   Exercise");
        Console.WriteLine("-----------------------------------------------------------------------");

        foreach (Exercise val in Enum.GetValues(typeof(Exercise)))
        {
            Console.WriteLine($"{(int)val }.    { val }");
        }
    }
}

