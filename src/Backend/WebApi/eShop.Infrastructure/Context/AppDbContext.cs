using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
