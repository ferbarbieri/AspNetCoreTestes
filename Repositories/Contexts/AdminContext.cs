using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories.Contexts
{
    public class AdminContext : DbContext
    {

        #region DBSets

        public DbSet<Usuario> Usuarios { get; set; }
        #endregion
        
        #region Config

        public AdminContext() => ChangeTracker.QueryTrackingBehavior =
               QueryTrackingBehavior.NoTracking;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamentos
            modelBuilder

                .Entity<Usuario>(entity =>
                {
                    entity
                    .ToTable("Usuario")
                    .HasQueryFilter(p => !p.IsDeleted);
                })
                ;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo: Refatorar para pegar de arquivo de configurações. - Estudar para pegar de base diferente dependendo do usuario.
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = AspNetCoreTestes; Trusted_Connection = True; ");
        }
        #endregion
    }
}
