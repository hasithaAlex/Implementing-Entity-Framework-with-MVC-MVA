using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02_MVA_Ex.Models.OneToOne
{
    public class MusicStoreDataContext : DbContext
    {
        public MusicStoreDataContext() : base("MyConnectionString") { }

        //one to one
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistDetails> ArtistDetails { get; set; }

        //one to many
        public DbSet<_02_MVA_Ex.Models.OneTowMany.Albam_OneTowMany> OneTowMany_tbl_Albams { set; get; }
        public DbSet<_02_MVA_Ex.Models.OneTowMany.Artist_OneTowMany> OneTowMany_tbl_Artists { set; get; }


    }
}