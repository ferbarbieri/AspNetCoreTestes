using Domain.Models;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Linq;
using Xunit;

namespace Tests.Repositorios
{
    public class ClienteRepositoryShould
    {
        
        [Theory]
        [Trait("Integration", "")]
        [Trait("Repositorios", "")]
        [InlineData("viceri.com.br")]
        [InlineData("bazooca.com.br")]
        public async void CriarObterAtualizarExcluirCliente(string tenant)
        {
            var options = new DbContextOptionsBuilder<LojaContext>();
            options.UseSqlServer($"Server = (localdb)\\mssqllocaldb; Database = {tenant}; Trusted_Connection = True;");

            // O certo é ter um teste por método!
            using (var context = new LojaContext(options.Options))
            {
                var repo = new ClienteRepository(context);
                var cliente = new Cliente("Fernando");
                await repo.Insert(cliente);

                Assert.NotEqual(default(int), cliente.Id);

                var clienteObter = await repo.GetById(cliente.Id);

                Assert.Equal("Fernando", clienteObter.Nome);

                cliente.UpdateInfo("Barbieri");

                await repo.Update(cliente);

                var lista = await repo.GetAllBy(c => c.Nome.StartsWith("Barb"));

                var clienteAtualizado = lista.FirstOrDefault();

                Assert.NotNull(clienteAtualizado.Nome);

                Assert.Equal("Barbieri", clienteAtualizado.Nome);
                
                await repo.Delete(cliente);

                var clienteExcluido = await repo.GetById(cliente.Id);

                Assert.Null(clienteExcluido);

            }
        }
    }
}
