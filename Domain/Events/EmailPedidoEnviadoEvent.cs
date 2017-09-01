using Domain.Models;
using Domain.RepositoryInterfaces;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class EmailPedidoEnviadoEvent : IDomainEvent
    {
        public EmailPedidoEnviadoEvent(Cliente cliente)
        {
            Cliente = cliente;
        }

        public Cliente Cliente { get; }
    }
}
