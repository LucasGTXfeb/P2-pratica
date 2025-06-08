using System.Linq;
using LojaVirtual.Entities;

namespace LojaVirtual.Services.Descontos
{
    public class DescontoPorQuantidade : IDescontoStrategy
    {
        private readonly int _quantidadeMinima;
        private readonly decimal _percentual;

        public DescontoPorQuantidade(int quantidadeMinima, decimal percentual)
        {
            _quantidadeMinima = quantidadeMinima;
            _percentual = percentual;
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            var totalComDesconto = pedido.Itens
                .Where(i => i.Quantidade >= _quantidadeMinima)
                .Sum(i => i.Subtotal * _percentual);

            return totalComDesconto;
        }
    }
}
