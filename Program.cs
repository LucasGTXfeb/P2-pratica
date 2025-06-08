using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Entities;
using LojaVirtual.Repositories;
using LojaVirtual.Factories;
using LojaVirtual.Services;
using LojaVirtual.Services.Descontos;

namespace LojaVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoRepo = new ProdutoRepository();
            var clienteRepo = new ClienteRepository();
            var pedidoFactory = new PedidoFactory();
            var pedidoService = new PedidoService(pedidoFactory);

            int idPedido = 1;
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n====== Menu Principal ======");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Cadastrar Cliente");
                Console.WriteLine("3 - Criar Pedido");
                Console.WriteLine("4 - Ver Pedidos");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("ID do Produto: ");
                        int idProduto = int.Parse(Console.ReadLine());

                        Console.Write("Nome do Produto: ");
                        string nomeProduto = Console.ReadLine();

                        Console.Write("Preço do Produto: ");
                        decimal preco = decimal.Parse(Console.ReadLine());

                        Console.Write("Categoria do Produto: ");
                        string categoria = Console.ReadLine();

                        try
                        {
                            var novoProduto = new Produto(idProduto, nomeProduto, preco, categoria);
                            produtoRepo.Cadastrar(novoProduto);
                            Console.WriteLine("Produto cadastrado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.Write("ID do Cliente: ");
                        int idCliente = int.Parse(Console.ReadLine());

                        Console.Write("Nome do Cliente: ");
                        string nomeCliente = Console.ReadLine();

                        Console.Write("Email do Cliente: ");
                        string email = Console.ReadLine();

                        Console.Write("CPF do Cliente: ");
                        string cpf = Console.ReadLine();

                        try
                        {
                            var novoCliente = new Cliente(idCliente, nomeCliente, email, cpf);
                            clienteRepo.Cadastrar(novoCliente);
                            Console.WriteLine("Cliente cadastrado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "3":
                        var clientes = clienteRepo.ObterTodos().ToList();
                        var produtos = produtoRepo.ObterTodos().ToList();

                        if (!clientes.Any())
                        {
                            Console.WriteLine("Nenhum cliente cadastrado.");
                            break;
                        }

                        if (!produtos.Any())
                        {
                            Console.WriteLine("Nenhum produto cadastrado.");
                            break;
                        }

                        Console.WriteLine("\nEscolha o cliente:");
                        for (int i = 0; i < clientes.Count; i++)
                            Console.WriteLine($"{i + 1} - {clientes[i].Nome}");

                        int indiceCliente = int.Parse(Console.ReadLine()) - 1;
                        var clienteSelecionado = clientes[indiceCliente];

                        var itens = new List<(Produto, int)>();
                        bool adicionando = true;

                        while (adicionando)
                        {
                            Console.WriteLine("\nEscolha o produto:");
                            for (int i = 0; i < produtos.Count; i++)
                                Console.WriteLine($"{i + 1} - {produtos[i].Nome} (R$ {produtos[i].Preco})");

                            int indiceProduto = int.Parse(Console.ReadLine()) - 1;
                            var produtoSelecionado = produtos[indiceProduto];

                            Console.Write("Quantidade: ");
                            int quantidade = int.Parse(Console.ReadLine());

                            itens.Add((produtoSelecionado, quantidade));

                            Console.Write("Adicionar mais produtos? (s/n): ");
                            adicionando = Console.ReadLine().ToLower() == "s";
                        }

                        Console.WriteLine("\nDeseja aplicar desconto?");
                        Console.WriteLine("1 - Por Categoria");
                        Console.WriteLine("2 - Por Quantidade");
                        Console.WriteLine("0 - Nenhum");

                        Console.Write("Opção: ");
                        string opcaoDesconto = Console.ReadLine();

                        IDescontoStrategy estrategia = null;

                        switch (opcaoDesconto)
                        {
                            case "1":
                                Console.Write("Informe a categoria para aplicar desconto: ");
                                string cat = Console.ReadLine();
                                estrategia = new DescontoPorCategoria(cat, 0.10m);
                                break;
                            case "2":
                                Console.Write("Informe a quantidade mínima para aplicar desconto: ");
                                int qtd = int.Parse(Console.ReadLine());
                                estrategia = new DescontoPorQuantidade(qtd, 0.05m);
                                break;
                            case "0":
                                Console.WriteLine("Sem desconto aplicado.");
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Nenhum desconto aplicado.");
                                break;
                        }

                        var pedido = pedidoService.CriarPedidoComDesconto(idPedido++, clienteSelecionado, itens, estrategia);

                        Console.WriteLine("\n--- Pedido Criado ---");
                        Console.WriteLine($"Cliente: {pedido.Cliente.Nome}");
                        Console.WriteLine($"Data: {pedido.Data}");
                        foreach (var item in pedido.Itens)
                        {
                            Console.WriteLine($"Produto: {item.Produto.Nome} | Qtd: {item.Quantidade} | Subtotal: R$ {item.Subtotal:0.00}");
                        }
                        Console.WriteLine($"Valor Total Bruto: R$ {pedido.ValorTotal:0.00}");
                        break;

                    case "4":
                        var pedidos = pedidoService.ObterPedidos().ToList();
                        if (!pedidos.Any())
                        {
                            Console.WriteLine("Nenhum pedido foi realizado ainda.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Lista de Pedidos ---");
                            foreach (var p in pedidos)
                            {
                                Console.WriteLine($"\nPedido #{p.Id} - {p.Cliente.Nome} - R$ {p.ValorTotal:0.00}");
                                foreach (var item in p.Itens)
                                {
                                    Console.WriteLine($"  {item.Produto.Nome} x{item.Quantidade} - Subtotal: R$ {item.Subtotal:0.00}");
                                }
                            }
                        }
                        break;

                    case "0":
                        executando = false;
                        Console.WriteLine("Encerrando o sistema. Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
