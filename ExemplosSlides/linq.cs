
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numeros = { 5, 10, 15, 20, 25 };

        var resultado = numeros.Where(n => n >= 10);

        foreach (int numero in resultado)
        {
            Console.WriteLine(numero);
        }
    }
}
