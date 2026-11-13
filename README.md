# Seminário C# — Linguagens de Programação

Repositório acadêmico dedicado ao estudo da linguagem de programação **C#** e de sua integração com a plataforma **.NET**, reunindo materiais teóricos, exemplos de código e uma aplicação prática desenvolvida em console.

## Autores

Projeto acadêmico desenvolvido por:

- **Márcio Mendes Gazzinelli Gomes**
- **Ian Campos Andrade**

**Instituição:** Pontifícia Universidade Católica de Minas Gerais (PUC Minas)  
**Curso:** Engenharia de Computação  
**Disciplina:** Linguagens de Programação  
**Ano:** 2026.

## Sobre o projeto

O objetivo do seminário é conhecer e compreender a linguagem de programação C#, explorando seu funcionamento, suas possibilidades de aplicação e sua integração com a plataforma .NET. Além disso, busca-se relacionar os conhecimentos adquiridos durante a pesquisa com a prática, por meio do desenvolvimento e da execução de exemplos de código.

O conteúdo aborda:

- História, evolução e influências da linguagem C#.
- Paradigmas de programação: orientado a objetos, imperativo, funcional e declarativo.
- Plataforma .NET, compilação e execução.
- Tipagem estática e forte.
- Programação genérica.
- Expressões lambda e LINQ.
- Tratamento de exceções.
- Gerenciamento automático de memória (Garbage Collector).
- Programação assíncrona com `async` e `await`.
- Linguagens relacionadas, comparações, vantagens e desvantagens.
- C# no mercado de trabalho.
- Parte prática: instalação e demonstração prática.


## Estrutura do repositório

```text
seminario-csharp/
│
├── Apresentacao/
│   ├── Seminario-CSharp.pptx
│   └── Seminario-CSharp.pdf
│
├── CadastroDeProduto/
│   ├── CadastroDeProduto.csproj
│   ├── Produto.cs
│   └── Program.cs
│
├── ExemplosSlides/
│   ├── assincrona.cs
│   ├── excecoes.cs
│   ├── genericos.cs
│   ├── gerenciamento-memoria.cs
│   ├── lambda.cs
│   ├── linq.cs
│   └── tipagem.cs
│
├── .gitignore
└── README.md
```

### Aplicação prática — Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio Code](https://code.visualstudio.com/) (opcional)

## Cadastro de Produtos

O projeto `CadastroDeProduto` é uma aplicação de console desenvolvida para demonstrar a utilização de diferentes recursos do C# em um mesmo programa.

A aplicação reúne conceitos como classes e objetos, listas, métodos, programação genérica, expressões lambda, LINQ, tratamento de exceções e programação assíncrona.

Seu objetivo é exemplificar a aplicação desses recursos em operações de cadastro e gerenciamento de produtos.

```bash
dotnet run --project CadastroDeProduto/CadastroDeProduto.csproj
```

## Exemplos dos slides

A pasta `ExemplosSlides` contém arquivos independentes que demonstram características específicas do C#.

```bash
dotnet run --file ExemplosSlides/assincrona.cs
```

## Referências

O desenvolvimento deste trabalho foi fundamentado em documentações oficiais, especificações técnicas, artigos e entrevistas com Anders Hejlsberg, criador da linguagem C#.

Entre as principais fontes consultadas, destacam-se:

- [Microsoft Learn — Documentação do C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [Microsoft Learn — Documentação do .NET](https://learn.microsoft.com/pt-br/dotnet/)
- [ECMA International — C# Language Specification](https://ecma-international.org/publications-and-standards/standards/ecma-334/)
- [Artima — The C# Design Process](https://www.artima.com/articles/the-c-design-process)
- [Red Gate — Anders Hejlsberg: Geek of the Week](https://www.red-gate.com/simple-talk/opinion/geek-of-the-week/anders-hejlsberg-geek-of-the-week/)
- [GitHub — The History of C# and TypeScript with Anders Hejlsberg](https://www.youtube.com/watch?v=uMqx8NNT4xY)

A lista completa de referências bibliográficas utilizadas na pesquisa está disponível nos slides da apresentação.

---

**PUC Minas — Engenharia de Computação**  
Disciplina: Linguagens de Programação  
Seminário acadêmico sobre C# e .NET — 2026