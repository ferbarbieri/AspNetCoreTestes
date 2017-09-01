using Domain.SharedKernel.Validation;

namespace Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        private Produto()
        {
        }

        public Produto(string nome, decimal preco)
        {
            // Validar a criação:
            new Guard()
                .NotNullOrEmpty("nome", nome)
                .GreaterThan("Preco", preco, 0)
                .Validate();

            Nome = nome;
            Preco = preco;
        }
    }
}