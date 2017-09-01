using Domain.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EventHandlers
{
    public class UsuarioCriadoEventHandler : IHandle<UsuarioCriadoEvent>
    {

        public void Handle(UsuarioCriadoEvent args)
        {
            Logger.Log($"Peguei o evento de Usuario Criado. O usuario é o {args.Usuario.Nome}.");
        }
    }
}
