using Domain.SharedKernel.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Pedido : Entity
    {
        public Cliente Cliente { get; private set; }
        public IList<ItensPedido> Itens { get; private set; }
        public decimal TotalPedido => Itens.Sum(i => i.PrecoTotal);

        private Pedido()
        {
        }

        public Pedido(Cliente cliente, IList<ItensPedidoDTO> itens)
        {
            new Guard()
                .NotNull("cliente", cliente)
                .HasMoreThanOne("itens", itens)
                .Validate();

            Itens = new List<ItensPedido>();

            // TODO: mudar para automapper
            foreach (var item in itens)
            {
                Itens.Add(new ItensPedido(this, item.Produto, item.Quantidade));
            }

            Cliente = cliente;
        }
    }
}
