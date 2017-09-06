using Domain.Models;
using SharedKernel;

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
