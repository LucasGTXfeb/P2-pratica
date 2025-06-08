using System.Linq;
using LojaVirtual.Entities;

namespace LojaVirtual.Services.Descontos
{
    public class DescontoPorCategoria : IDescontoStrategy
    {
        private readonly string _categoria;
        private readonly decimal _percentual;

        public DescontoPorCategoria(string categoria, decimal percentual)
        {
            _categoria = categoria;
            _percentual = percentual;
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            var totalDaCategoria = pedido.Itens
                .Where(i => i.Produto.Categoria.ToLower() == _categoria.ToLower())
                .Sum(i => i.Subtotal);

            return totalDaCategoria * _percentual;
        }
    }
}
