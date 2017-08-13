using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _02_MVA_Ex.Models.OneTowMany
{
    public class Artist_OneTowMany
    {
        public int Artist_OneTowManyID { get; set; }

        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        
        public virtual ICollection<Albam_OneTowMany> Albums { get; set; }
    }
}