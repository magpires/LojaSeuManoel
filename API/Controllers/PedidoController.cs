using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicos.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServico _servico;

        public PedidoController(IPedidoServico servico)
        {
            _servico = servico;
        }

        [HttpPost("processa-lista-pedidos")]
        [AllowAnonymous]
        public IActionResult ProcessaListaPedidos(RequisicaoPedidosDto requisicaoPedidosDto)
        {
            var response =  _servico.ProcessaListaPedidos(requisicaoPedidosDto);

            return Ok(response);
        }
    }
}
