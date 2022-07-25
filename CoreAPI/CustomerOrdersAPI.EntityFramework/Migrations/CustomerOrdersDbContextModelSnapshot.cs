﻿// <auto-generated />
using System;
using CustomerOrdersAPI.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerOrdersAPI.EntityFramework.Migrations
{
    [DbContext(typeof(CustomerOrdersDbContext))]
    partial class CustomerOrdersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerOrdersAPI.EntityFramework.Models.Material", b =>
                {
                    b.Property<string>("MaterialId")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MaterialName")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(50)");

                    b.HasKey("MaterialId")
                        .HasName("MaterialId");

                    b.ToTable("tblMaterial");
                });

            modelBuilder.Entity("CustomerOrdersAPI.EntityFramework.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerOrderId")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("MaterialId")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("MaterialQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<string>("OriginAddress")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("QuantityUnit")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TotalWeight")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WeightUnit")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("OrderId")
                        .HasName("OrderId");

                    b.ToTable("tblOrder");
                });

            modelBuilder.Entity("CustomerOrdersAPI.EntityFramework.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OrderStatusDescription")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(50)");

                    b.HasKey("OrderStatusId")
                        .HasName("OrderStatusId");

                    b.ToTable("tblOrderStatusDescription");
                });
#pragma warning restore 612, 618
        }
    }
}