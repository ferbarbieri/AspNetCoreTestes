using Domain.Events;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EventHandlers
{
    public class UserCreatedEventHandler : IHandle<UsuarioCriadoEvent>
    {

        public void Handle(UsuarioCriadoEvent args)
        {
            Logger.Log($"Peguei o User Created Event No Repositorio. O usuario é o {args.Usuario.Nome}.");
        }
    }
}
