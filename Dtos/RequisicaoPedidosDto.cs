using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class RequisicaoPedidosDto
    {
        public PedidoDto[] Pedidos { get; set; } = Array.Empty<PedidoDto>();

        public void Valida()
        {
            bool listaPedidosVazia = Pedidos.Length == 0;

            if (listaPedidosVazia)
                throw new Exception("A lista de pedidos está vazia.");

            bool existeMenoresIguaisZero = Pedidos.Any(p => p.Pedido_Id <= 0);

            if (existeMenoresIguaisZero)
                throw new Exception("Um ou mais pedidos possuem o pedido_id menor ou igual a zero");

            bool existeDuplicados = Pedidos
                .GroupBy(p => p.Pedido_Id)
                .Any(g => g.Count() > 1);

            if (existeDuplicados)
                throw new Exception("Um ou mais pedidos possuem o mesmo pedido_id");

            PedidoDto? pedidoComProdutosVazios = Pedidos.FirstOrDefault(p => p.Produtos.Any() == false);

            if (pedidoComProdutosVazios != null)
                throw new Exception($"O pedido de id {pedidoComProdutosVazios.Pedido_Id} possui a lista de produtos vazia.");

            PedidoDto? pedidoComProdutoInvalido = Pedidos.FirstOrDefault(p => p.Produtos.Any(prod => string.IsNullOrWhiteSpace(prod.Produto_Id)));

            if (pedidoComProdutoInvalido != null)
                throw new Exception($"O pedido de id {pedidoComProdutoInvalido.Pedido_Id} contém um produto com produto_id nulo ou vazio.");

            ProdutoDto? produtoComDimensoesInvalidas = Pedidos
                .SelectMany(p => p.Produtos)
                .FirstOrDefault(prod =>
                    prod.Dimensoes.Altura <= 0 ||
                    prod.Dimensoes.Largura <= 0 ||
                    prod.Dimensoes.Comprimento <= 0);

            if (produtoComDimensoesInvalidas != null)
            {
                throw new Exception($"O produto {produtoComDimensoesInvalidas.Produto_Id} possui dimensões inválidas.");
            }
        }
    }
}
    