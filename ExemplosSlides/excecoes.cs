using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int a = 10;
        int b = 0;

        try
        {
            int resultado = a / b;
            Console.WriteLine(resultado);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Erro: divisão por zero!");
        }
        finally
        {
            Console.WriteLine("Operação finalizada.");
        }

        Console.WriteLine("Programa continua.");
    }
}
