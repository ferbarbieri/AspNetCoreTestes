using Xunit;
using NSubstitute;
using Domain.RepositoryInterfaces;
using Domain.Models;
using Application;
using Application.Input;

namespace Tests.Application
{
    public class ClienteApplicationServiceShould
    {

        [Trait ("Unit Test", "AppService")]
        [Theory]
        [InlineData("Fernando")]
        async void InserirNovoCliente(string nome)
        {

            var cliente = new ClienteInput { Nome = "Fernando", Email = "Fernando@viceri.com.br" };

            // Mock do Repositorio de clientes
            var _repo = Substitute.For<IClienteRepository>();

            var svc = new ClienteApplicationService(_repo);

            var c = await svc.Adicionar(cliente);

            Assert.NotNull(c);
        }

    }
}
