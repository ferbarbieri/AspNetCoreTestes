using Domain.Models;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ClienteCriadoEvent : IDomainEvent
    {
        public Cliente Cliente { get; set; }

        public ClienteCriadoEvent(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}
