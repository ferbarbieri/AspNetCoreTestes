using Domain.Events;
using Domain.RepositoryInterfaces;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EventHandlers
{
    public class EmailPedidoEnviadoHandler : IHandle<EmailPedidoEnviadoEvent>
    {
        public void Handle(EmailPedidoEnviadoEvent args)
        {
            Logger.Log($"Peguei o Pedido Enviado dentro do Application!: Já mandei o email para  { args.Cliente.Nome }: Fazer alguma coisa aqui.");
        }
    }
}
