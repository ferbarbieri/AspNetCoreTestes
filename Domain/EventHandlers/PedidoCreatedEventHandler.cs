using Domain.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EventHandlers
{
    public class PedidoCreatedEventHandler : IHandle<PedidoCriadoEvent>
    {
        public void Handle(PedidoCriadoEvent args)
        {
            Logger.Log($"Peguei o Pedido Created Event. Pedido Numero: { args.Pedido.Id }, enviar email para o usuario { args.Pedido.Cliente.Nome }");
            // manda o email
            DomainEvents.Raise(new EmailPedidoEnviadoEvent(args.Pedido.Cliente));
        }
    }
}
