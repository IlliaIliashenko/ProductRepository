using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Configuration
{
    public class UserConfiguration :IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            var hasher = new PasswordHasher<UserEntity>();
            builder.HasData(
                new UserEntity()
                {
                    Id = 1,
                    Login = "admin",
                    PasswordHash = hasher.HashPassword(null, "admin")
                });
        }
    }
}