using Domain.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ItensPedidoDTO
    {
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

        public ItensPedidoDTO(Produto produto, int quantidade)
        {
            new Guard()
                .NotNull("produto", produto)
                .GreaterThan("quantidade", quantidade, 0)
                .Validate();

            Produto = produto;
            Quantidade = quantidade;
        }
    }
}
