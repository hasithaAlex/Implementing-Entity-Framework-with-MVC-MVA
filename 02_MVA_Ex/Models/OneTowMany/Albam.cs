using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _02_MVA_Ex.Models.OneTowMany
{
    public class Albam_OneTowMany
    {
        public int Albam_OneTowManyID { set; get; }
        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public String Title { get; set; }

        public int ArtistID { get; set; }
        public virtual Artist_OneTowMany Artist { get; set; }
    }
}