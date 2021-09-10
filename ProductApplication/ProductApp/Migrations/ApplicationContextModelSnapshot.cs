﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApp.DAL.Data;

namespace ProductApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductApp.DAL.Models.Authentication.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "31d31fb9-69a5-4917-8a8e-3516761b53cd",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "8b68b3e2-198e-4531-8ea8-f8b564ae7ef2",
                            RoleName = "Guest"
                        });
                });

            modelBuilder.Entity("ProductApp.DAL.Models.Authentication.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0c9feadc-51c9-4993-9f69-1bf3e21c2f0c",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Login = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAECyKSGiOe8SyiIaHw2ufbQF4If8iTsjVK/r4YoOfM3PybRpXveqDhNVOHPUKI2RnaQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("ProductApp.DAL.Models.Authentication.UserRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleEntity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ProductApp.DAL.Models.Product.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Integrated with 6GB GDDR5 192-bit memory interface",
                            Name = "GigaByte GTX1660",
                            Price = 499.99m,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 2,
                            Description = "12 GB GDDR6 (192bit), Connection via PCIe 4.0",
                            Name = "EVGA RTX3060",
                            Price = 849.99m,
                            Quantity = 43
                        },
                        new
                        {
                            Id = 3,
                            Description = "8.0 GB GDDR5 (256bit), Connection via 3.0",
                            Name = "XFX RX580",
                            Price = 619.99m,
                            Quantity = 12
                        },
                        new
                        {
                            Id = 4,
                            Description = "4.0 GB GDDR5 (128bit), Connection via 3.0",
                            Name = "MSI GTX1650",
                            Price = 279.99m,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "8.0 GB GDDR6 (256bit), Connection via 3.0",
                            Name = "PNY RTX4000",
                            Price = 1017.90m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 6,
                            Description = "8.0 GB GDDR5 (256bit), Connection via 3.0",
                            Name = "XFX RX580 GTS",
                            Price = 619.99m,
                            Quantity = 53
                        },
                        new
                        {
                            Id = 7,
                            Description = "6.0 GB GDDR6 (192bit), Connection via 3.0",
                            Name = "MSI GTX1660Ti",
                            Price = 649.99m,
                            Quantity = 19
                        },
                        new
                        {
                            Id = 8,
                            Description = "2.0 GB GDDR5 (64bit), Connection via 3.0",
                            Name = "ASUS GT1030 ",
                            Price = 104.84m,
                            Quantity = 123
                        },
                        new
                        {
                            Id = 9,
                            Description = "2.0 GB GDDR5 (64bit), Connection via 2.0",
                            Name = "ASUS 710",
                            Price = 64.90m,
                            Quantity = 35
                        },
                        new
                        {
                            Id = 10,
                            Description = "16.0 GB GDDR6 (256bit), Connection via 3.0",
                            Name = "PNY RTX5000",
                            Price = 2079.00m,
                            Quantity = 9
                        });
                });

            modelBuilder.Entity("ProductApp.DAL.Models.Authentication.UserRoleEntity", b =>
                {
                    b.HasOne("ProductApp.DAL.Models.Authentication.RoleEntity", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductApp.DAL.Models.Authentication.UserEntity", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductApp.DAL.Models.Authentication.RoleEntity", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ProductApp.DAL.Models.Authentication.UserEntity", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}