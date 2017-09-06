using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Repositories.Contexts
{
    public class LojaDbContextFactory : IDesignTimeDbContextFactory<LojaContext>
    {
        public LojaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LojaContext>();
            builder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = AspNetCoreTestes; Trusted_Connection = True;");
            return new LojaContext(builder.Options);
        }
    }
}
