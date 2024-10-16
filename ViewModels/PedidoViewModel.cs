using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PedidoViewModel
    {
        public int Pedido_id { get; set; }
        public List<CaixaViewModel> Caixas { get; set; } = new List<CaixaViewModel>();
    }
}
