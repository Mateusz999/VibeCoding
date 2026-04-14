// Lesson no. 1 - Implicit conversion
using System;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;

/*
short a = 10;
short b = 10;

short c = (short)(a + b);

Console.WriteLine(c.GetType());
Console.WriteLine(((short)(a+b)).GetType());
Console.WriteLine(((a+b)).GetType());
*/
// Lesson no. 2 Why These Two C# Structs Have Different Sizes ?

/*public struct StructOne
{
    public char a, b;
    public int x;
    public char c, d;
}

public struct StructTwo
{
    public char a, b,c,d;
    public int x;
}


partial class Program
{
    static void Main()
    {
        Console.WriteLine(Marshal.SizeOf<StructOne>());
        Console.WriteLine(Marshal.SizeOf<StructTwo>());
    }
}

*/
// Observe the code snippet belong. Can you guess the output ?

//Console.WriteLine((1.0 / 0));


// A: 0
// B: Infinity
// C: Exception
// D: NaN

int a = 10;
int b = 20;


(a, b) = (b, a);


Console.WriteLine($"{a} {b}");


// C#: Check if a number is a power of two.

Console.WriteLine(IsPowerOfTwo(11));
Console.WriteLine(IsPowerOfTwo(2));
bool IsPowerOfTwo(int n) => n > 0 && (n & (n - 1)) == 0;




bool IsValid(User u) => u is { Age: >= 18, Name.Length: > 0 };












internal class User
{
    public int Age { get; internal set; }
    public string? Name { get; internal set; }
}