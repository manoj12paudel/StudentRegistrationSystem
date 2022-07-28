using Microsoft.EntityFrameworkCore;

namespace StudentRegestrationSystem.Models
{
   
    public class Databasecontext : DbContext
    {
        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options)
        {
           



        }
        public DbSet<record> records { get; set; }
        public DbSet<payment> payments { get; set; }


    }
}

