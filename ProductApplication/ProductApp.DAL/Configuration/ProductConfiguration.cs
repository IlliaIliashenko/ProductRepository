using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.DAL.Models.Product;

namespace ProductApp.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasData(new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "GigaByte GTX1660",
                    Description = "Integrated with 6GB GDDR5 192-bit memory interface",
                    Price = 499.99m,
                    Quantity = 15
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "EVGA RTX3060",
                    Description = "12 GB GDDR6 (192bit), Connection via PCIe 4.0",
                    Price = 849.99m,
                    Quantity = 43
                },
                new ProductEntity()
                {
                    Id = 3,
                    Name = "XFX RX580",
                    Description = "8.0 GB GDDR5 (256bit), Connection via 3.0",
                    Price = 619.99m,
                    Quantity = 12
                },
                new ProductEntity()
                {
                    Id = 4,
                    Name = "MSI GTX1650",
                    Description = "4.0 GB GDDR5 (128bit), Connection via 3.0",
                    Price = 279.99m,
                    Quantity = 3
                },
                new ProductEntity()
                {
                    Id = 5,
                    Name = "PNY RTX4000",
                    Description = "8.0 GB GDDR6 (256bit), Connection via 3.0",
                    Price = 1017.90m,
                    Quantity = 20
                },
                new ProductEntity()
                {
                    Id = 6,
                    Name = "XFX RX580 GTS",
                    Description = "8.0 GB GDDR5 (256bit), Connection via 3.0",
                    Price = 619.99m,
                    Quantity = 53
                },
                new ProductEntity()
                {
                    Id = 7,
                    Name = "MSI GTX1660Ti",
                    Description = "6.0 GB GDDR6 (192bit), Connection via 3.0",
                    Price = 649.99m,
                    Quantity = 19
                },
                new ProductEntity()
                {
                    Id = 8,
                    Name = "ASUS GT1030 ",
                    Description = "2.0 GB GDDR5 (64bit), Connection via 3.0",
                    Price = 104.84m,
                    Quantity = 123
                },
                new ProductEntity()
                {
                    Id = 9,
                    Name = "ASUS 710",
                    Description = "2.0 GB GDDR5 (64bit), Connection via 2.0",
                    Price = 64.90m,
                    Quantity = 35
                },
                new ProductEntity()
                {
                    Id = 10,
                    Name = "PNY RTX5000",
                    Description = "16.0 GB GDDR6 (256bit), Connection via 3.0",
                    Price = 2079.00m,
                    Quantity = 9
                },

            });
        }
    }
}