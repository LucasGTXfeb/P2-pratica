using System.Collections.Generic;
using LojaVirtual.Entities;

namespace LojaVirtual.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new();

        public void Cadastrar(Produto produto)
        {
            _produtos.Add(produto);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtos;
        }
    }
}