using Microsoft.EntityFrameworkCore;
using ProductApp.DAL.Configuration;
using ProductApp.DAL.Models.Authentication;
using ProductApp.DAL.Models.Product;

namespace ProductApp.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<ProductEntity> ProductEntities { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}