using System.Collections.Generic;
using LojaVirtual.Entities;

namespace LojaVirtual.Factories
{
    public interface IPedidoFactory
    {
        Pedido CriarPedido(int id, Cliente cliente, List<(Produto produto, int quantidade)> itens);
    }
}
