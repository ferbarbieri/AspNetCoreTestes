using Domain.Models;
using Infra.Repositories.Contexts.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories.Contexts
{
    public class TenantManagementContext : DbContext
    {

        #region DBSets

        public DbSet<Tenant> Tenants { get; set; }
        #endregion

        #region Config

        public TenantManagementContext(DbContextOptions<TenantManagementContext> options) : base(options) =>
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamentos
            modelBuilder
                .AddDefaultProperties()
                .Entity<Tenant>(entity =>
                {
                    entity
                    .ToTable("Tenant")
                    .AddIsDeletedFilter()
                    .HasIndex(c => c.Dominio).IsUnique();

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
