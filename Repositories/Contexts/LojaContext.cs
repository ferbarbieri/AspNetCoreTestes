using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories.Contexts
{
    public class LojaContext : DbContext
    {
        #region DBSets

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItensPedido> ItemPedido { get; set; }

        #endregion

        #region Config

        public LojaContext() => ChangeTracker.QueryTrackingBehavior =
                QueryTrackingBehavior.NoTracking;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento de tabelas
            modelBuilder

                .Entity<Cliente>(entity =>
                {
                    entity
                    .ToTable("Cliente")
                    .HasQueryFilter(p => !p.IsDeleted);
                })

                .Entity<Pedido>(entity =>
                {
                    entity
                    .ToTable("Pedido")
                    .HasQueryFilter(p => !p.IsDeleted);
                })

                .Entity<Produto>(entity =>
                {
                    entity
                    .ToTable("Produto")
                    .HasQueryFilter(p => !p.IsDeleted);
                })

                .Entity<ItensPedido>(entity =>
                {
                    entity
                    .ToTable("ItemPedido")
                    .HasKey(x => new { x.PedidoId, x.ProdutoId});
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
