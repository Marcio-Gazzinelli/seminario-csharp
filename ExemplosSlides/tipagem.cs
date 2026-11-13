class Program
{
    static void Main()
    {
        int idade = 20;
        string nome = "Carlos";
        bool aprovado = true;

        idade = "vinte"; // Erro de tipo
        int soma = idade + aprovado; // Erro de tipo

        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Idade: {idade}");
        Console.WriteLine($"Aprovado: {aprovado}");
    }
}