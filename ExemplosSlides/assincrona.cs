using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Iniciando consulta...");

        Task consulta = ConsultarAsync();

        Console.WriteLine("Executando outra atividade.");

        await consulta;

        Console.WriteLine("Programa finalizado.");
    }

    static async Task ConsultarAsync()
    {
        await Task.Delay(15000);
        Console.WriteLine("Consulta concluída!");
    }
}
