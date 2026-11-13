using System;

class Program
{
    static void Main()
    {
        static void Mostrar<T>(T valor)
        {
            Console.WriteLine(valor);
        }
        
        Mostrar<int>(10);
        Mostrar<string>("Ola");
        Mostrar<double>(3.5);
    }
}