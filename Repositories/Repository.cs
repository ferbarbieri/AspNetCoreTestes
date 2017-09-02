using Domain.Models;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.SharedKernel.Queries;

namespace Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>, IDisposable 
        where TEntity : Entity
        where TContext : DbContext
    {
        protected TContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
       
        public virtual TEntity GetById(int id)
        {
            return DbSet.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }
        public IList<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking()
                .Where(predicate).ToList();
        }

        public PaginatedResults<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, PaginationInput paginationInput)
        {
            var count = DbSet.Where(predicate).Count();

            var results = DbSet.AsNoTracking()
                .Where(predicate)
                .Skip(paginationInput.RecordsToSkip)
                .Take(paginationInput.RecordsPerPage)
                .ToList();

            return new PaginatedResults<TEntity>(
                results: results, 
                totalRecords: count, 
                currentPage: paginationInput.CurrentPage, 
                recordsPerPage: paginationInput.RecordsPerPage);
        }

        public PaginatedResults<TEntity> GetAll(PaginationInput paginationInput)
        {
            // TODO: Ver melhor jeito de fazer isso sem repetir
            var count = DbSet.Count();

            var results = DbSet.AsNoTracking()
                .Skip(paginationInput.RecordsToSkip)
                .Take(paginationInput.RecordsPerPage)
                .ToList();

            return new PaginatedResults<TEntity>(
                results: results,
                totalRecords: count,
                currentPage: paginationInput.CurrentPage,
                recordsPerPage: paginationInput.RecordsPerPage);
        }
        
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }
        
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
