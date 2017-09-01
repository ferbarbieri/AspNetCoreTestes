using Domain.SharedKernel.Validation;

namespace Domain.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        
        private Usuario()
        {
        }

        public void AtualizarNome(string novoNome)
        {
            new Guard()
                .NotNullOrEmpty("Nome", novoNome)
                .Validate();

            Nome = novoNome;
        }


        public Usuario(string nome)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .Validate();

            Nome = nome;
        }

        
    }
}
