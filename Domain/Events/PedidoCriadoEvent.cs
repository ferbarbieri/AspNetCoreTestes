using Domain.Models;
using SharedKernel;

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
