using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.HasData(
                new UserRoleEntity()
                {
                    Id = 1,
                    RoleId = 1,
                    UserId = 1,

                });
        }
    }
}