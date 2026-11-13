
using System;

class Produto
{
    public string Nome;

    public Produto(string nome)
    {
        Nome = nome;
    }
}

class Program
{
    static void Main()
    {
        CriarProduto();
        Console.WriteLine("Programa finalizado.");
    }

    static void CriarProduto()
    {
        Produto produto = new Produto("Mouse");
        Console.WriteLine(produto.Nome);
    }
}
