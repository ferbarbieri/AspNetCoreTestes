using Domain.Models;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.SharedKernel.Queries;
using System.Threading.Tasks;

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
       
        public virtual Task<TEntity> GetById(int id)
        {
            return DbSet.FirstOrDefaultAsync(c => c.Id == id);
        }
        public Task<List<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToListAsync();
        }

        public async Task<PaginatedResults<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate, PaginationInput paginationInput)
        {
            var count = DbSet.Where(predicate).Count();

            var results = await DbSet.AsNoTracking()
                .Where(predicate)
                .Skip(paginationInput.RecordsToSkip)
                .Take(paginationInput.RecordsPerPage)
                .ToListAsync();

            return new PaginatedResults<TEntity>(
                results: results, 
                totalRecords: count, 
                currentPage: paginationInput.CurrentPage, 
                recordsPerPage: paginationInput.RecordsPerPage);
        }

        public async Task<PaginatedResults<TEntity>> GetAll(PaginationInput paginationInput)
        {
            var count = DbSet.Count();

            var results = await DbSet.AsNoTracking()
                .Skip(paginationInput.RecordsToSkip)
                .Take(paginationInput.RecordsPerPage)
                .ToListAsync();

            return new PaginatedResults<TEntity>(
                results: results,
                totalRecords: count,
                currentPage: paginationInput.CurrentPage,
                recordsPerPage: paginationInput.RecordsPerPage);
        }

        
        public virtual Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return Db.SaveChangesAsync();
        }

        public virtual Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            return Db.SaveChangesAsync();
        }

        public virtual Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            return Db.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
