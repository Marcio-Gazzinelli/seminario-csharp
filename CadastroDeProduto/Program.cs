using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

partial class Program
{
    // Lista genérica que armazena objetos Produto.
    static readonly List<Produto> produtos = new();

    // async permite utilizar await dentro de Main.
    static async Task Main()
    {
        CultureInfo.CurrentCulture =
            new CultureInfo("pt-BR");

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Produtos iniciais para facilitar a demonstração.
        produtos.Add(new Produto("Mouse", 80m, 5));
        produtos.Add(new Produto("Teclado", 150m, 3));
        produtos.Add(new Produto("Monitor", 900m, 2));

        // Estrutura de repetição do paradigma imperativo.
        while (true)
        {
            Console.WriteLine("\n=== SISTEMA DE PRODUTOS ===");
            Console.WriteLine("1 - Cadastrar produto (Tipagem estática e forte, Tratamento de exceções)");
            Console.WriteLine("2 - Listar produtos (Programação genérica)");
            Console.WriteLine("3 - Filtrar produtos por preço (LINQ, Expressões lambda)");
            Console.WriteLine("4 - Calcular valor do estoque (LINQ, Expressões lambda)");
            Console.WriteLine("5 - Agrupar quantidades por produto (Programação genérica, LINQ, Expressões lambda)");
            Console.WriteLine("6 - Gerar relatório do estoque (Programação assíncrona, LINQ, Expressões lambda)");
            Console.WriteLine("7 - Demonstrar Garbage Collector (Gerenciamento de memória)");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha uma opção: ");

            string? entrada = Console.ReadLine();
            if (entrada is null)
            {
                return;
            }

            if (!TentarLerInteiroNaoNegativo(entrada, out int opcao)
                || opcao > 7)
            {
                Console.WriteLine("Opção inválida. Digite um número de 0 a 7.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;

                case 2:
                    ListarProdutos();
                    break;

                case 3:
                    FiltrarProdutos();
                    break;

                case 4:
                    CalcularEstoque();
                    break;

                case 5:
                {
                    // Em Dictionary<TKey, TValue>, a chave é string e o valor é long.
                    // O compilador verifica esses tipos ao acessar o dicionário.
                    var quantidadesPorNome = new Dictionary<string, long>(
                        StringComparer.OrdinalIgnoreCase
                    );

                    foreach (Produto produto in produtos)
                    {
                        quantidadesPorNome.TryGetValue(produto.Nome, out long quantidadeAtual);
                        quantidadesPorNome[produto.Nome] = quantidadeAtual + produto.Quantidade;
                    }

                    Console.WriteLine("\n=== QUANTIDADE POR PRODUTO ===");
                    foreach (var grupo in quantidadesPorNome.OrderBy(grupo => grupo.Key))
                    {
                        Console.WriteLine($"{grupo.Key} | {grupo.Value} unidade(s)");
                    }
                    break;
                }

                case 6:
                {
                    Console.WriteLine("\nPreparando relatório do estoque...");

                    // Simula uma consulta externa. O temporizador começa aqui.
                    Task consulta = Task.Delay(3000);

                    // Enquanto a consulta está pendente, calculamos os dados locais.
                    long totalUnidades = produtos.Sum(produto => (long)produto.Quantidade);
                    decimal valorTotal = produtos.Sum(produto => produto.ValorTotal());
                    Console.WriteLine("Totais calculados. Aguardando a consulta...");

                    // Aguarda a tarefa sem bloquear uma thread durante a espera.
                    await consulta;

                    Console.WriteLine("\n=== RELATÓRIO DO ESTOQUE ===");
                    Console.WriteLine($"Registros cadastrados: {produtos.Count}");
                    Console.WriteLine($"Unidades em estoque: {totalUnidades}");
                    Console.WriteLine($"Valor do estoque: {valorTotal:C2}");
                    break;
                }

                case 7:
                    DemonstrarMemoria();
                    break;

                case 0:
                    Console.WriteLine("Encerrando programa...");
                    return;
            }
        }
    }
}
