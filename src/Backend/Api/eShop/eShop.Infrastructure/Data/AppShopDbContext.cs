using eShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Data
{
    public partial class AppShopDbContext : DbContext
    {
        public AppShopDbContext(DbContextOptions<AppShopDbContext> opt) : base(opt)
        {

        }

        public virtual DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
