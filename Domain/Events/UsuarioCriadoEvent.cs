using Domain.Models;
using SharedKernel;

namespace Domain.Events
{
    public class UsuarioCriadoEvent : IDomainEvent
    {
        public Usuario Usuario { get; set; }

        public UsuarioCriadoEvent(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
