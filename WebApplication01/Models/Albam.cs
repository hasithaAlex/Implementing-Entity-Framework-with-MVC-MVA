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
}