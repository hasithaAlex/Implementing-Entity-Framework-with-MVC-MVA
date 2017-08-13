using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_MVA_Ex_RepoPatern.Models.Models
{
    public class Albam
    {
        public int AlbamID { set; get; }

        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public String Title { get; set; }

        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        
    }
}