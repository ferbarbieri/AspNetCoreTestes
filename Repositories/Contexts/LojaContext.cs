using Domain.Models;
using Infra.Repositories.Contexts.Config;
using Microsoft.EntityFrameworkCore;

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

        public LojaContext(DbContextOptions<LojaContext> options) : base(options) =>
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento de tabelas
            modelBuilder
                .AddDefaultProperties()
                .Entity<Cliente>(entity =>
                {
                    entity
                    .ToTable("Cliente")
                    .AddIsDeletedFilter();
                })

                .Entity<Pedido>(entity =>
                {
                    entity
                    .ToTable("Pedido")
                    .AddIsDeletedFilter();
                })

                .Entity<Produto>(entity =>
                {
                    entity
                    .ToTable("Produto")
                    .AddIsDeletedFilter();
                })

                .Entity<ItensPedido>(entity =>
                {
                    entity
                    .ToTable("ItemPedido")
                    .HasKey(x => new { x.PedidoId, x.ProdutoId });
                })
                ;
            
        }

        #endregion

        public override int SaveChanges()
        {
            // Adiciono as propriedades padrão para serem tratadas na hora de salvar.
            DefaultPropertiesConfig.SaveDefaultPropertiesChanges(ChangeTracker);
            return base.SaveChanges();
        }
    }
}
