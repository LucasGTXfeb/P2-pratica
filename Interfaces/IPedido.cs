using System;
using System.Collections.Generic;

namespace LojaVirtual.Entities
{
    public interface IPedido
    {
        int Id { get; }
        Cliente Cliente { get; }
        List<ItemPedido> Itens { get; }
        DateTime Data { get; }
        decimal ValorTotal { get; }

        void AdicionarItem(ItemPedido item);
    }
}
