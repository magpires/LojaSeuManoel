using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class PedidoDto
    {
        public int Pedido_id { get; set; }
        public IEnumerable<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();
    }
}
