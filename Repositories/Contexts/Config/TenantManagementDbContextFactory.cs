using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Repositories.Contexts
{
    public class TenantManagementDbContextFactory : IDesignTimeDbContextFactory<TenantManagementContext>
    {
        public TenantManagementContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TenantManagementContext>();
            builder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = AspNetCoreTestes; Trusted_Connection = True;");
            return new TenantManagementContext(builder.Options);
        }
    }
}
