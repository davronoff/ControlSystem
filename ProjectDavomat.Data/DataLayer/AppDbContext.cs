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
        public DbSet<Teacher> teachers {get; set;}
        public DbSet<User> students { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Course> courses { get; set; }

    }
}