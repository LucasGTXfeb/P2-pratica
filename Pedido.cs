using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Entities
{
    public class Pedido : IPedido
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public decimal ValorTotal => Itens.Sum(item => item.Subtotal);

        public Pedido(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            Itens = new List<ItemPedido>();
            Data = DateTime.Now;
        }

        public void AdicionarItem(ItemPedido item)
        {
            if (item == null)
                throw new ArgumentException("Item não pode ser nulo.");

            Itens.Add(item);
        }
    }
}
