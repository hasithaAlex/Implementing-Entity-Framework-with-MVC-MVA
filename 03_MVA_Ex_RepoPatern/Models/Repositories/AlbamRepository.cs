using _03_MVA_Ex_RepoPatern.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVA_Ex_RepoPatern.Models.Repositories
{
    public class AlbamRepository : Repository<Albam>
    {
        public List<Albam> GetByName(String name)
        {
            return DbSet.Where(a => a.Title.Contains(name)).ToList();
        }

        
    }
}