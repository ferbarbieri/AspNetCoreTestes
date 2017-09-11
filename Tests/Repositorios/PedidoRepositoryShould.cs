using Domain.Models;
using Infra.Repositories.Contexts;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Repositorios
{
    public class PedidoRepositoryShould
    {
        
        [Fact]
        [Trait("Integration", "")]
        [Trait("Repositorios", "")]
        public async void CriarPedido()
        {
            // O certo é ter um teste por método!
            using (var context = new LojaContext(ContextOptions<LojaContext>.GetOptions()))
            {
                var clienteRepo = new ClienteRepository(context);
                var cliente = (await clienteRepo.GetAllBy(c => !string.IsNullOrEmpty(c.Nome)))[0];

                var itens = context.Produto.ToList().Take(2).ToList();

                var itensPedido = new List<ItensPedidoDTO>();

                foreach (var item in itens)
                {
                    itensPedido.Add(new ItensPedidoDTO(item, 5));
                }

                var pedido = new Pedido(cliente, itensPedido);

                var pedidoRepo = new PedidoRepository(context);
                await pedidoRepo.Insert(pedido);

                Assert.True(pedido.Id > 0);

            }
        }
    }
}
