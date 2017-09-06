using Domain.Events;
using SharedKernel;

namespace Domain.EventHandlers
{
    public class ClienteCriadoEventHandler : IHandle<ClienteCriadoEvent>
    {

        public void Handle(ClienteCriadoEvent args)
        {
            Logger.Log($"Peguei o evento de Cliente Criado. O cliente é o {args.Cliente.Nome}.");
        }
    }
}
