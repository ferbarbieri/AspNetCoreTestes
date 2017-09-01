using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

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
