using Domain.Models;
using Infra.Repositories.Contexts;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.Repositorios
{
    public class UsuarioRepositoryShould
    {
        
        [Fact]
        [Trait("Type", "Integration")]
        [Trait("Repositorios", "Usuario")]
        public void CriarObterAtualizarExcluirUsuario()
        {
            // O certo é ter um teste por método!
            using (var context = new AdminContext(ContextOptions<AdminContext>.GetOptions()))
            {
                var repo = new UsuarioRepository(context);
                var usuario = new Usuario("Fernando");
                repo.Insert(usuario);

                Assert.NotEqual(default(int), usuario.Id);

                var usuarioObter = repo.GetById(usuario.Id);

                Assert.Equal("Fernando", usuarioObter.Nome);

                usuario.AtualizarNome("Barbieri");

                repo.Update(usuario);

                var usuarioAtualizado = repo.GetAllBy(c => c.Nome.StartsWith("Barb")).FirstOrDefault();

                Assert.NotNull(usuarioAtualizado.Nome);

                Assert.Equal("Barbieri", usuarioAtualizado.Nome);
                
                repo.Delete(usuario);

                var usuarioExcluido = repo.GetById(usuario.Id);

                Assert.Null(usuarioExcluido);

            }
        }
    }
}
