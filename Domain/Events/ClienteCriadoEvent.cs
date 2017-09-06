using Domain.Models;
using SharedKernel;

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
