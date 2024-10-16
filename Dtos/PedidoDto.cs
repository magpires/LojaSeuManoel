using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class PedidoDto
    {
        public int Pedido_Id { get; set; }
        public ProdutoDto[] Produtos { get; set; } = Array.Empty<ProdutoDto>();
    }
}
