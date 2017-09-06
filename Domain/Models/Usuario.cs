using Domain.Enums;
using Domain.Events;
using Domain.SharedKernel.Utils;
using Domain.SharedKernel.Validation;
using SharedKernel;

namespace Domain.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public PerfilUsuario Perfil { get; private set; }


        private Usuario()
        {
        }

        /// <summary>
        /// Promove um usuario para administador.
        /// </summary>
        public void PromoverParaAdministrador()
        {
            Perfil = PerfilUsuario.Administradores;

            // Lanço um evento para que outros locais possam fazer as tarefas necessárias.
            DomainEvents.Raise(new UsuarioPromovidoParaAdministradorEvent(this));
        }

        public Usuario(string nome, string email, string senha)
        {
            // Senha obrigatória na criação:
            new Guard()
                    .ValidPassword("Senha", senha)
                    .Validate();

            UpdateInfo(nome, email, senha);
            
            // Por padrão todo usuário é comum.
            Perfil = PerfilUsuario.Usuarios;
        }

        public void UpdateInfo(string nome, string email, string senha = null)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .ValidEmail("Email", email)
                .Validate();

            if(senha != null)
                new Guard()
                    .ValidPassword("Senha", senha)
                    .Validate();
            
            bool usuarioAlterouEmail = false;

            if (!string.IsNullOrEmpty(Email) && Email != email)
                usuarioAlterouEmail = true;

            Nome = nome;
            Email = email;

            if (senha != null)
                Senha = PasswordHasher.Hash(senha);

            // Lança evento de alteração de email.
            if (usuarioAlterouEmail)
                DomainEvents.Raise(new UsuarioAlterouEmailEvent(this));
        }
    }
}
