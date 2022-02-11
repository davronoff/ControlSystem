using Microsoft.EntityFrameworkCore;
using ProjectDavomat.Domain;

namespace ProjectDavomat.Data
{
    public class DavomatDbContext: DbContext
    {
        public DavomatDbContext(DbContextOptions<DavomatDbContext>options)
            :base(options)
        {

        }
        public DbSet<Oqituvchi> teachers {get; set;}
        public DbSet<Oquvchi> puples { get; set; }
    }
}