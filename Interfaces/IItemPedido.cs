namespace LojaVirtual.Entities
{
    public interface IItemPedido
    {
        Produto Produto { get; }
        int Quantidade { get; }
        decimal Subtotal { get; }
    }
}
