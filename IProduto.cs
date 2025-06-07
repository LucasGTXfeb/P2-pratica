namespace LojaVirtual.Entities
{
    public interface IProduto
    {
        int Id { get; }
        string Nome { get; }
        decimal Preco { get; }
        string Categoria { get; }
    }
}
