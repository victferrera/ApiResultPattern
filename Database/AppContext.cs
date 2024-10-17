using ApiResultPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiResultPattern.Database
{
    public class AppContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppContext(DbContextOptions<AppContext> opt) :
            base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
    }
}
