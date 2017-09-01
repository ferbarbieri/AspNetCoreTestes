using Domain.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

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
