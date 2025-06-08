namespace LojaVirtual.Services.Descontos
{
    public class DescontoContext
    {
        private IDescontoStrategy _estrategia;

        public void DefinirEstrategia(IDescontoStrategy estrategia)
        {
            _estrategia = estrategia;
        }

        public decimal CalcularDesconto(Entities.Pedido pedido)
        {
            if (_estrategia == null)
                return 0;

            return _estrategia.CalcularDesconto(pedido);
        }
    }
}
