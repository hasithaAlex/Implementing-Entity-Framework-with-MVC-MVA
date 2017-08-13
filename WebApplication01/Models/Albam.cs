using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication01.Models
{
    public class Albam
    {
        public int AlbamId { get; set; }

        [Required()]
        [StringLength(1000,MinimumLength =2)]
        public string Title { get; set; }
        public decimal Price { get; set; }


        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }

    }
}