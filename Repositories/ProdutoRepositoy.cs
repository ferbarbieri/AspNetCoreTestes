using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using System;

namespace Repositories
{
    public class ProdutoRepository : Repository<Produto, LojaContext>, IProdutoRepository
    {
        public ProdutoRepository(LojaContext context) : base(context)
        {
        }
    }
}
