using System;
using System.Collections.Generic;
using LojaVirtual.Entities;
using LojaVirtual.Factories;
using LojaVirtual.Services.Descontos;

namespace LojaVirtual.Services
{
    public class PedidoService
    {
        private readonly IPedidoFactory _pedidoFactory;
        private readonly List<Pedido> _pedidos;
        private readonly DescontoContext _descontoContext;

        public PedidoService(IPedidoFactory pedidoFactory)
        {
            _pedidoFactory = pedidoFactory;
            _pedidos = new List<Pedido>();
            _descontoContext = new DescontoContext();
        }

        public Pedido CriarPedidoComDesconto(int id, Cliente cliente, List<(Produto, int)> itens, IDescontoStrategy estrategia)
        {
            var pedido = _pedidoFactory.CriarPedido(id, cliente, itens);
            _descontoContext.DefinirEstrategia(estrategia);
            var desconto = _descontoContext.CalcularDesconto(pedido);

            Console.WriteLine($"\nDesconto aplicado: R$ {desconto:0.00}");
            Console.WriteLine($"Total com desconto: R$ {(pedido.ValorTotal - desconto):0.00}");

            _pedidos.Add(pedido);
            return pedido;
        }

        public IEnumerable<Pedido> ObterPedidos()
        {
            return _pedidos;
        }
    }
}
