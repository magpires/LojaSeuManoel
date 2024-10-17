using Dtos;
using Models;
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
        private readonly List<Caixa> _caixasDisponiveis = new List<Caixa>
        {
            new Caixa("Caixa 1", 30, 40, 80),
            new Caixa("Caixa 2", 80, 50, 40),
            new Caixa("Caixa 3", 50, 80, 60)
        };

        public RespostaPedidosViewModel ProcessaListaPedidos(RequisicaoPedidosDto requisicaoPedidosDto)
        {
            requisicaoPedidosDto.Valida();

            RespostaPedidosViewModel resposta = new RespostaPedidosViewModel();

            foreach (PedidoDto pedido in requisicaoPedidosDto.Pedidos)
            {
                PedidoViewModel pedidoViewModel = ProcessaPedido(pedido);
                resposta.Pedidos.Add(pedidoViewModel);
            }

            return resposta;
        }

        private PedidoViewModel ProcessaPedido(PedidoDto pedido)
        {
            PedidoViewModel pedidoViewModel = new PedidoViewModel
            {
                Pedido_id = pedido.Pedido_Id
            };

            List<ProdutoDto> produtosNaoAlocados = new List<ProdutoDto>(pedido.Produtos);

            foreach (Caixa caixa in _caixasDisponiveis)
            {
                List<string> produtosNaCaixa = new List<string>();

                produtosNaoAlocados.RemoveAll(produto =>
                {
                    if (ProdutoCabeNaCaixa(produto, caixa))
                    {
                        produtosNaCaixa.Add(produto.Produto_Id);
                        return true;
                    }
                    return false;
                });

                if (produtosNaCaixa.Any())
                {
                    pedidoViewModel.Caixas.Add(new CaixaViewModel
                    {
                        Caixa_id = caixa.Caixa_Id,
                        Produtos = produtosNaCaixa
                    });
                }
            }

            if (produtosNaoAlocados.Any())
            {
                pedidoViewModel.Caixas.Add(new CaixaViewModel
                {
                    Caixa_id = null,
                    Produtos = produtosNaoAlocados.Select(p => p.Produto_Id).ToList(),
                    Observacao = "Produto não cabe em nenhuma caixa disponível."
                });
            }

            return pedidoViewModel;
        }

        private bool ProdutoCabeNaCaixa(ProdutoDto produto, Caixa caixa)
        {
            return (produto.Dimensoes.Altura <= caixa.Altura &&
                    produto.Dimensoes.Largura <= caixa.Largura &&
                    produto.Dimensoes.Comprimento <= caixa.Comprimento) ||
                   (produto.Dimensoes.Altura <= caixa.Largura &&
                    produto.Dimensoes.Largura <= caixa.Comprimento &&
                    produto.Dimensoes.Comprimento <= caixa.Altura);
        }
    }
}
