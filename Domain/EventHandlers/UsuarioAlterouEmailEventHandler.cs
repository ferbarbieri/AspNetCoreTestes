using Domain.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EventHandlers
{
    public class UsuarioAlterouEmailEventHandler : IHandle<UsuarioAlterouEmailEvent>
    {

        public void Handle(UsuarioAlterouEmailEvent args)
        {
            Logger.Log($"O usuario {args.Usuario.Nome} agora é alterou seu email para {args.Usuario.Email}. Enviar email de confirmação.");
        }
    }
}
