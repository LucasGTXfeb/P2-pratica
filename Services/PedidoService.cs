using System;
using System.Collections.Generic;
using LojaVirtual.Entities;
using LojaVirtual.Factories;
using LojaVirtual.Repositories;

namespace LojaVirtual.Services
{
    public class PedidoService
    {
        private readonly IPedidoFactory _pedidoFactory;
        private readonly List<Pedido> _pedidos;

        public PedidoService(IPedidoFactory pedidoFactory)
        {
            _pedidoFactory = pedidoFactory;
            _pedidos = new List<Pedido>();
        }

        public Pedido CriarPedido(int id, Cliente cliente, List<(Produto, int)> itens)
        {
            var pedido = _pedidoFactory.CriarPedido(id, cliente, itens);
            _pedidos.Add(pedido);
            return pedido;
        }

        public IEnumerable<Pedido> ObterPedidos()
        {
            return _pedidos;
        }
    }
}
