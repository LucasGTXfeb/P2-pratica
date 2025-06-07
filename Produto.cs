using System;

namespace LojaVirtual.Entities
{
    public class Produto : IProduto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Categoria { get; private set; }

        public Produto(int id, string nome, decimal preco, string categoria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto inválido.");
            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero.");
            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("Categoria inválida.");

            Id = id;
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }
    }
}

