using Domain.Events;
using SharedKernel;

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
