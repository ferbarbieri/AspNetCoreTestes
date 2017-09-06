using Domain.Models;
using SharedKernel;

namespace Domain.Events
{
    public class UsuarioPromovidoParaAdministradorEvent : IDomainEvent
    {
        public Usuario Usuario { get; set; }

        public UsuarioPromovidoParaAdministradorEvent(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
