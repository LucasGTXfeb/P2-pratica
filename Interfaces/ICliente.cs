namespace LojaVirtual.Entities
{
    public interface ICliente
    {
        int Id { get; }
        string Nome { get; }
        string Email { get; }
        string Cpf { get; }
    }
}