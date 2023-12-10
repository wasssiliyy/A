using A.Entities;
using Microsoft.EntityFrameworkCore;

namespace A.Data
{
    public class MoviewDbContext : DbContext
    {
        public MoviewDbContext(DbContextOptions<MoviewDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
