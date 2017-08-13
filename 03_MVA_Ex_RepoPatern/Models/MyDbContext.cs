using _03_MVA_Ex_RepoPatern.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _03_MVA_Ex_RepoPatern.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConnectionString") { }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Albam> Albams { get; set; }

    }
}