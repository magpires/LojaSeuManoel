using Dtos;
using Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Servicos
{
    public class PedidoServico : IPedidoServico
    {
        public RespostaPedidosViewModel ProcessaListaPedidos(RequisicaoPedidosDto requisicaoPedidosDto)
        {
            return new RespostaPedidosViewModel();
        }
    }
}
