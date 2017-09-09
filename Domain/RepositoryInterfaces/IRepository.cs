using Domain.Models;
using Domain.SharedKernel.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetById(int id);

        Task<List<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate);

        Task<PaginatedResults<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate, PaginationInput paginationInput);

        Task<PaginatedResults<TEntity>> GetAll(PaginationInput paginationInput);

        Task Update(TEntity entity);

        Task Insert(TEntity entity);

        Task Delete(TEntity entity);
    }
}
