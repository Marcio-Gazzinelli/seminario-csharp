
using System;

// Classe que representa um produto do sistema.
public class Produto
{
    // Propriedades de cada produto.
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    // Construtor: executado ao criar um novo Produto.
    public Produto(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    // Método que calcula o valor total do estoque.
    public decimal ValorTotal()
    {
        return Preco * Quantidade;
    }

    // Define como o produto será exibido como texto.
    public override string ToString()
    {
        return $"{Nome} | Preço: {Preco:C2} | " +
               $"Quantidade: {Quantidade}";
    }
}
