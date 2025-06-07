using System;
using LojaVirtual.Entities;
using LojaVirtual.Repositories;

namespace LojaVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoRepo = new ProdutoRepository();
            var clienteRepo = new ClienteRepository();

            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n====== Menu Principal ======");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Cadastrar Cliente");
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
