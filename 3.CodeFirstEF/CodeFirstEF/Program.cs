using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Models;

namespace CodeFirstEF
{

    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PlutoContext() 
        :base("name = DefaultConnection")
        {
           
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
