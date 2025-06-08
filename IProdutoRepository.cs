using System.Collections.Generic;
using LojaVirtual.Entities;

namespace LojaVirtual.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        IEnumerable<Produto> ObterTodos();
    }
}