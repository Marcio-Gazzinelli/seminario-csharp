using System;

class Program
{
    static void Main()
    {
        Func<int, int> dobrar = n => n * 2;

        Console.WriteLine(dobrar(5));
        Console.WriteLine(dobrar(10));
    }
}
