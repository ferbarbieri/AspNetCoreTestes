using Domain.SharedKernel.Validation;

namespace Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }

        private Cliente()
        {
        }

        public Cliente(string nome)
        {
            new Guard()
                .NotNullOrEmpty("Nome", nome)
                .Validate();

            Nome = nome;
        }

        public void UpdateInfo(string novoNome)
        {
            new Guard()
                .NotNullOrEmpty("Nome", novoNome)
                .Validate();

            Nome = novoNome;
        }
    }
}
