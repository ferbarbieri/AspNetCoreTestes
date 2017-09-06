using Domain.Models;
using Infra.Repositories.Contexts;
using Repositories;
using System.Linq;
using Xunit;

namespace Tests.Repositorios
{
    public class ClienteRepositoryShould
    {
        
        [Fact]
        [Trait("Integration", "")]
        [Trait("Repositorios", "")]
        public void CriarObterAtualizarExcluirCliente()
        {
            // O certo é ter um teste por método!
            using (var context = new LojaContext(ContextOptions<LojaContext>.GetOptions()))
            {
                var repo = new ClienteRepository(context);
                var cliente = new Cliente("Fernando");
                repo.Insert(cliente);

                Assert.NotEqual(default(int), cliente.Id);

                var clienteObter = repo.GetById(cliente.Id);

                Assert.Equal("Fernando", clienteObter.Nome);

                cliente.UpdateInfo("Barbieri");

                repo.Update(cliente);

                var clienteAtualizado = repo.GetAllBy(c => c.Nome.StartsWith("Barb")).FirstOrDefault();

                Assert.NotNull(clienteAtualizado.Nome);

                Assert.Equal("Barbieri", clienteAtualizado.Nome);
                
                repo.Delete(cliente);

                var clienteExcluido = repo.GetById(cliente.Id);

                Assert.Null(clienteExcluido);

            }
        }
    }
}
