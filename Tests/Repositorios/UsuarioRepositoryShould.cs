using Domain.Models;
using Infra.Repositories.Contexts;
using Repositories;
using System;
using System.Linq;
using Xunit;

namespace Tests.Repositorios
{
    public class UsuarioRepositoryShould
    {

        [Fact(Skip ="Não funciona DomainEvents")]
        [Trait("Integration", "")]
        [Trait("Repositorios", "")]
        public async void CriarObterAtualizarExcluirUsuario()
        {
            // O certo é ter um teste por método!
            using (var context = new AdminContext(ContextOptions<AdminContext>.GetOptions()))
            {
                var repo = new UsuarioRepository(context);
                var usuario = new Usuario("Fernando", $"fernando_{DateTime.Now.Millisecond}_{DateTime.Now.Second}@viceri.com.br", "12345678");
                await repo.Insert(usuario);

                Assert.NotEqual(default(int), usuario.Id);

                var usuarioObter = await repo.GetById(usuario.Id);

                Assert.Equal("Fernando", usuarioObter.Nome);

                usuario.UpdateInfo("Barbieri", "NovoEmail@lala.com");

                usuario.PromoverParaAdministrador();

                await repo.Update(usuario);

                var lista = await repo.GetAllBy(c => c.Nome.StartsWith("Barb"));

                var usuarioAtualizado = lista.FirstOrDefault();

                Assert.NotNull(usuarioAtualizado.Nome);

                Assert.Equal("Barbieri", usuarioAtualizado.Nome);
                
                await repo.Delete(usuario);

                var usuarioExcluido = repo.GetById(usuario.Id);

                Assert.Null(usuarioExcluido);

            }
        }
    }
}
