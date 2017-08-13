using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication01.Models.Repositories;

namespace WebApplication01.Models.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public List<Artist> GetByName(String name)
        {
            return DbSet.Where(a => a.Name.Contains(name)).ToList();         
        }


    }
}