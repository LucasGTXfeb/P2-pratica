using System.Collections.Generic;
using LojaVirtual.Entities;

namespace LojaVirtual.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
    }
}