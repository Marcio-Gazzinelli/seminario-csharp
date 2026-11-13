using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

partial class Program
{
    static void CadastrarProduto()
    {
        Console.Write("\nNome do produto: ");
        string? entradaNome = Console.ReadLine();
        if (entradaNome is null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(entradaNome)
            || entradaNome.Any(c => char.IsControl(c) || char.GetUnicodeCategory(c) == UnicodeCategory.Format))
        {
            Console.WriteLine("Nome inválido. Informe um nome visível e sem caracteres de controle.");
            return;
        }

        string nome = string.Join(" ", entradaNome.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries))
            .Normalize(NormalizationForm.FormC);

        if (produtos.Any(produto => string.Equals(produto.Nome, nome, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Já existe um produto com esse nome.");
            return;
        }

        Console.Write("Preço (ex.: 19,90): ");
        string? entradaPreco = Console.ReadLine();
        if (entradaPreco is null)
        {
            return;
        }

        if (!TentarLerPreco(entradaPreco, out decimal preco))
        {
            Console.WriteLine("Preço inválido. Use um valor não negativo, sem separador de milhar e com até duas casas decimais.");
            return;
        }

        Console.Write("Quantidade: ");
        string? entradaQuantidade = Console.ReadLine();
        if (entradaQuantidade is null)
        {
            return;
        }

        if (!TentarLerInteiroNaoNegativo(entradaQuantidade, out int quantidade))
        {
            Console.WriteLine($"Quantidade inválida. Digite um número inteiro de 0 a {int.MaxValue:N0}, sem separador de milhar.");
            return;
        }

        var novo = new Produto(nome, preco, quantidade);

        try
        {
            // Verifica o valor do produto e a soma antes de alterar a lista.
            // Assim, o relatório e o cálculo do estoque podem usar esses valores.
            decimal valorTotal = produtos.Sum(produto => produto.ValorTotal()) + novo.ValorTotal();
            if (valorTotal >= 100_000_000_000_000_000_000_000_000m)
            {
                Console.WriteLine("O valor total do estoque excederia o limite aceito.");
                return;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("O preço e a quantidade informados geram um valor de estoque grande demais.");
            return;
        }

        produtos.Add(novo);
        Console.WriteLine("Produto cadastrado!");
    }

    static bool TentarLerInteiroNaoNegativo(string entrada, out int numero)
    {
        numero = 0;
        string texto = entrada.Trim();
        return texto.All(char.IsAsciiDigit)
            && int.TryParse(texto, NumberStyles.None, CultureInfo.CurrentCulture, out numero);
    }

    static bool TentarLerPreco(string entrada, out decimal preco)
    {
        preco = 0;
        string texto = entrada.Trim();

        // Limita a parte inteira a 26 dígitos para representar os centavos com precisão.
        return Regex.IsMatch(texto, @"\A[0-9]{1,26}(,[0-9]{1,2})?\z")
            && decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out preco);
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\n=== PRODUTOS ===");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        // foreach percorre os objetos da lista.
        foreach (Produto produto in produtos)
        {
            Console.WriteLine(produto);
        }
    }

    static void FiltrarProdutos()
    {
        Console.Write("\nPreço mínimo: ");

        string? entradaPreco = Console.ReadLine();
        if (entradaPreco is null)
        {
            return;
        }

        if (!TentarLerPreco(entradaPreco, out decimal precoMinimo))
        {
            Console.WriteLine("Preço inválido. Use um valor não negativo, sem separador de milhar e com até duas casas decimais.");
            return;
        }

        // LINQ: Where filtra e OrderBy ordena.
        // A expressão => representa uma função lambda.
        var resultado = produtos
            .Where(p => p.Preco >= precoMinimo)
            .OrderBy(p => p.Preco);

        Console.WriteLine("\nProdutos encontrados:");

        bool encontrou = false;

        // A consulta Where é executada durante a enumeração.
        foreach (Produto produto in resultado)
        {
            Console.WriteLine(produto);
            encontrou = true;
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum produto encontrado.");
        }
    }

    static void CalcularEstoque()
    {
        // Sum soma os valores retornados pela expressão lambda.
        decimal total = produtos.Sum(
            p => p.ValorTotal()
        );

        Console.WriteLine(
            $"\nValor total do estoque: {total:C2}"
        );
    }

    static void DemonstrarMemoria()
    {
        Console.WriteLine("\n=== GARBAGE COLLECTOR ===");

        // Memória gerenciada antes do teste.
        long antes = GC.GetTotalMemory(false);

        // Método que cria vários objetos temporários.
        CriarObjetosTemporarios();

        // Memória gerenciada após as alocações.
        long depois = GC.GetTotalMemory(false);

        Console.WriteLine(
            $"Memória antes: {antes / 1024.0 / 1024.0:F2} MB"
        );

        Console.WriteLine(
            $"Memória após criar objetos: " +
            $"{depois / 1024.0 / 1024.0:F2} MB"
        );

        // Força uma coleta apenas para demonstração.
        // Não é recomendado fazer isso normalmente.
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long aposGC = GC.GetTotalMemory(false);

        Console.WriteLine(
            $"Memória após solicitar coleta: " +
            $"{aposGC / 1024.0 / 1024.0:F2} MB"
        );

        Console.WriteLine(
            "Os valores podem variar conforme o Runtime."
        );
    }

    static void CriarObjetosTemporarios()
    {
        // Lista temporária de arrays de bytes.
        List<byte[]> temporarios = new();

        for (int i = 0; i < 500; i++)
        {
            // Cada array possui 64 KiB.
            temporarios.Add(new byte[64 * 1024]);
        }

        Console.WriteLine(
            $"Objetos temporários criados: {temporarios.Count}"
        );

        // Após o método terminar, se não houver
        // outras referências ativas, os objetos
        // poderão ser recolhidos pelo GC.
    }
}
