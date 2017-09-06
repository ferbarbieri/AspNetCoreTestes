using Domain.SharedKernel.Validation;

namespace Domain.Models
{
    public class ItensPedido
    {
        public int PedidoId { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public Produto Produto { get; private set; }
        public decimal PrecoTotal => Quantidade * Produto.Preco;

        private ItensPedido()
        {
        }

        public ItensPedido(Pedido pedido, Produto produto, int quantidade)
        {
            new Guard()
                .NotNull("Pedido", pedido)
                .NotNull("Produto", produto)
                .GreaterThan("Quantidade", quantidade, 0)
                .Validate();
            

            ProdutoId = produto.Id;
            Produto =  produto;
            PedidoId = pedido.Id;
            Quantidade = quantidade;
        }
        
    }

    

}
