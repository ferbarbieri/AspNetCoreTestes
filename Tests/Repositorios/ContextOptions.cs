﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Repositorios
{
    public static class ContextOptions<T> where T: DbContext
    {
        public static DbContextOptions<T> GetOptions()
        {
            var options = new DbContextOptionsBuilder<T>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = AspNetCoreTestes; Trusted_Connection = True;");
            return options.Options;
        }
    }
}
