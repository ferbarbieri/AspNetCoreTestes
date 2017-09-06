using Domain.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EventHandlers
{
    public class UsuarioPromovidoParaAdmnistradorEventHandler : IHandle<UsuarioPromovidoParaAdministradorEvent>
    {

        public void Handle(UsuarioPromovidoParaAdministradorEvent args)
        {
            Logger.Log($"O usuario {args.Usuario.Nome} agora é administrador. Aqui posso fazer alguma coisa.");
        }
    }
}
