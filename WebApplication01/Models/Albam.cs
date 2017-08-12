using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication01.Models
{
    public class Albam
    {
        public int AlbamId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class MusixContext : DbContext
    {
        public MusixContext()
        {
            Database.Log = s => Debug.WriteLine(s);
        }
        public DbSet<Albam> Albams { get; set; }
    }
}