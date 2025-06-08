using LojaVirtual.Entities;

namespace LojaVirtual.Services.Descontos
{
    public interface IDescontoStrategy
    {
        decimal CalcularDesconto(Pedido pedido);
    }
}
