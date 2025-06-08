using System.Collections.Generic;
using LojaVirtual.Entities;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes = new();

        public void Cadastrar(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clientes;
        }
    }
}