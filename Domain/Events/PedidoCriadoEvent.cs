using Domain.Models;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class PedidoCriadoEvent : IDomainEvent
    {

        public Pedido Pedido { get; private set; }

        public PedidoCriadoEvent(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
