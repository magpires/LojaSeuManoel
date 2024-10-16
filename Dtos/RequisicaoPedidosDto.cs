using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class RequisicaoPedidosDto
    {
        public IEnumerable<PedidoDto> Pedidos { get; set; } = new List<PedidoDto>();
    }
}
    