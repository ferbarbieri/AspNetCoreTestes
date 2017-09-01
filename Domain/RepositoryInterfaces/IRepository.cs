using Domain.Models;
using Domain.SharedKernel.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);

        IList<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate);

        PaginatedResults<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, PaginationInput paginationInput);

        PaginatedResults<TEntity> GetAll(PaginationInput paginationInput);

        void Update(TEntity entity);

        void Insert(TEntity entity);

        void Delete(TEntity entity);
    }
}
