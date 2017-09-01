using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repositories.Contexts.Config
{
    public static class DefaultPropertiesConfig
    {
        internal static ModelBuilder AddDefaultProperties(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                modelBuilder.Entity(entityType.Name).Property<bool>("IsDeleted");
            }
            return modelBuilder;
        }

        internal static EntityTypeBuilder AddIsDeletedFilter<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T:Entity
        {
            entityTypeBuilder.HasQueryFilter(c => !EF.Property<bool>(c, "IsDeleted"));
            return entityTypeBuilder;
        }

        internal static void SaveDefaultPropertiesChanges(ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries()
             .Where(e => e.State == EntityState.Added ||
                         e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = DateTime.Now;
            }

            foreach (var entry in changeTracker.Entries()
              .Where(p => p.State == EntityState.Deleted
              && p.Entity is Entity))
            {
                entry.Property("IsDeleted").CurrentValue = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
