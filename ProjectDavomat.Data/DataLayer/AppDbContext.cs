using Microsoft.EntityFrameworkCore;
using ProjectDavomat.Domain;

namespace ProjectDavomat.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base(options)
        {

        }
        public DbSet<Oqituvchi> teachers {get; set;}
        public DbSet<Oquvchi> students { get; set; }
    }
}