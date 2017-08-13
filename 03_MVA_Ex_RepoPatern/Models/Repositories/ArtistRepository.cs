using _03_MVA_Ex_RepoPatern.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVA_Ex_RepoPatern.Models.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public List<Artist> GetByName(String name)
        {
            return DbSet.Where(a => a.Name.Contains(name)).ToList();
        }
    }
}