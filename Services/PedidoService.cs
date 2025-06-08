using System;
using System.Collections.Generic;
using LojaVirtual.Entities;
using LojaVirtual.Factories;
using LojaVirtual.Services.Descontos;
using LojaVirtual.Services.Logs;

namespace LojaVirtual.Services
{
    public class PedidoService
    {
        private readonly IPedidoFactory _pedidoFactory;
        private readonly List<Pedido> _pedidos;
        private readonly DescontoContext _descontoContext;
        private readonly ILogger _logger;

        public PedidoService(IPedidoFactory pedidoFactory, ILogger logger)
        {
            _pedidoFactory = pedidoFactory;
            _descontoContext = new DescontoContext();
            _logger = logger;
            _pedidos = new List<Pedido>();
        }

        public Pedido CriarPedidoComDesconto(int id, Cliente cliente, List<(Produto, int)> itens, IDescontoStrategy estrategia)
        {
            var pedido = _pedidoFactory.CriarPedido(id, cliente, itens);
            _descontoContext.DefinirEstrategia(estrategia);
            var desconto = _descontoContext.CalcularDesconto(pedido);

            pedido.ValorComDesconto = pedido.ValorTotal - desconto;

            _logger.Registrar($"Pedido #{id} criado para {cliente.Nome} - Total bruto: R$ {pedido.ValorTotal:0.00}, Desconto: R$ {desconto:0.00}");

            _pedidos.Add(pedido);
            return pedido;
        }

        public IEnumerable<Pedido> ObterPedidos()
        {
            return _pedidos;
        }
    }
}
