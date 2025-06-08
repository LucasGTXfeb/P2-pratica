using System;
using System.Collections.Generic;
using LojaVirtual.Entities;

namespace LojaVirtual.Factories
{
    public class PedidoFactory : IPedidoFactory
    {
        public Pedido CriarPedido(int id, Cliente cliente, List<(Produto produto, int quantidade)> itens)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            if (itens == null || itens.Count == 0)
                throw new ArgumentException("O pedido precisa ter pelo menos um item.");

            var pedido = new Pedido(id, cliente);

            foreach (var (produto, quantidade) in itens)
            {
                var item = new ItemPedido(produto, quantidade);
                pedido.AdicionarItem(item);
            }

            return pedido;
        }
    }
}
