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
    }
}
