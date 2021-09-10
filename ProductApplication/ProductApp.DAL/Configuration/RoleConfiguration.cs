using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasData(
                new RoleEntity()
                {
                    Id = 1,
                    RoleName = "Admin"
                },
                new RoleEntity()
                {
                    Id = 2,
                    RoleName = "Guest"
                });
        }
    }
}