﻿// <auto-generated />

using CustomerManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerManagementSystem.Migrations
{
    [DbContext(typeof(OnlineDbContext))]
    partial class OnlineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShopingCart.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddToCartAndDatabase");

                    b.Property<string>("Address");

                    b.Property<int>("Discount");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ItemPurchase");

                    b.Property<string>("Name");

                    b.Property<int>("TotalPurchase");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");
                });

            modelBuilder.Entity("OnlineShopingCart.Models.Enquiry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Discount");

                    b.Property<string>("ItemPurchase");

                    b.Property<string>("Name");

                    b.Property<int>("TotalPurchase");

                    b.HasKey("Id");

                    b.ToTable("Enquiries");
                });

            modelBuilder.Entity("OnlineShopingCart.Models.GoldCustomer", b =>
                {
                    b.HasBaseType("OnlineShopingCart.Models.Customer");


                    b.ToTable("GoldCustomer");

                    b.HasDiscriminator().HasValue("GoldCustomer");
                });

            modelBuilder.Entity("OnlineShopingCart.Models.SilverCustomer", b =>
                {
                    b.HasBaseType("OnlineShopingCart.Models.Customer");


                    b.ToTable("SilverCustomer");

                    b.HasDiscriminator().HasValue("SilverCustomer");
                });
#pragma warning restore 612, 618
        }
    }
}