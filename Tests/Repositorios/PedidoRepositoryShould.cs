using Domain.Models;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Repositorios
{
    public class PedidoRepositoryShould
    {
        
        [Theory]
        [Trait("Integration", "")]
        [Trait("Repositorios", "")]
        [InlineData("viceri.com.br")]
        [InlineData("bazooca.com.br")]
        public async void CriarPedido(string tenant)
        {
            var options = new DbContextOptionsBuilder<LojaContext>();
            options.UseSqlServer($"Server = (localdb)\\mssqllocaldb; Database = {tenant}; Trusted_Connection = True;");
            
            // O certo é ter um teste por método!
            using (var context = new LojaContext(options.Options))
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
