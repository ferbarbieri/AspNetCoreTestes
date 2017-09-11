using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Repositories.Contexts.Config;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Contexts
{
    public class AdminContext : DbContext
    {

        #region DBSets

        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        #region Config

        public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }
        
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            DefaultPropertiesConfig.SaveDefaultPropertiesChanges(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
