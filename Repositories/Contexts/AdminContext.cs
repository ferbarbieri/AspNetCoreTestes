using Domain.Models;
using Infra.Repositories.Contexts.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infra.Repositories.Contexts
{
    public class AdminContext : DbContext
    {

        #region DBSets

        public DbSet<Usuario> Usuarios { get; set; }
        #endregion
        
        #region Config

        public AdminContext(DbContextOptions<AdminContext> options) : base(options) => 
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamentos
            modelBuilder
                .AddDefaultProperties()
                .Entity<Usuario>(entity =>
                {
                    entity
                    .ToTable("Usuario")
                    .AddIsDeletedFilter()
                    .HasIndex(c => c.Email).IsUnique();
                    
                });

            // Adiciona também as propriedades padrão para todas as entidades
        }
        
        #endregion

        public override int SaveChanges()
        {
            DefaultPropertiesConfig.SaveDefaultPropertiesChanges(ChangeTracker);
            return base.SaveChanges();
        }
    }
}
