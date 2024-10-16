using Dtos;
using ViewModels;

namespace Servicos.Interfaces
{
    public interface IPedidoServico
    {
        RespostaPedidosViewModel ProcessaListaPedidos(RequisicaoPedidosDto requisicaoPedidosDto);
    }
}
