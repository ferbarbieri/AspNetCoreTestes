using Domain.Models;
using SharedKernel;

namespace Domain.Events
{
    public class UsuarioAlterouEmailEvent : IDomainEvent
    {
        public Usuario Usuario { get; set; }

        public UsuarioAlterouEmailEvent(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
