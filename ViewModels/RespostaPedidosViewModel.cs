using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class RespostaPedidosViewModel
    {
        public List<PedidoViewModel> Pedidos { get; set; } = new List<PedidoViewModel>();
    }
}
