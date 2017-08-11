using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusixContext()) {

                var count = context.Albams.Count();
                Console.WriteLine(count);

                context.Albams.Add(new Albam { Price =10, Title="Looks Grate"});
                context.SaveChanges();

                count = context.Albams.Count();
                Console.WriteLine(count);

                var albams = context.Albams
                    .Where(o=>o.Price ==10).ToList();
                Console.WriteLine(albams.Count());


                Console.ReadLine();
            }
        }
    }

    public class Albam {
        public int AlbamId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class MusixContext : DbContext {
        public DbSet<Albam> Albams { get; set; }
    } 
}
