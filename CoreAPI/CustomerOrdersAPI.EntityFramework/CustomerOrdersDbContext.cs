using CustomerOrdersAPI.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.EntityFramework
{
    public class CustomerOrdersDbContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public CustomerOrdersDbContext(DbContextOptions<CustomerOrdersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("tblMaterial");
            modelBuilder.Entity<OrderStatus>().ToTable("tblOrderStatusDescription");
            modelBuilder.Entity<Order>().ToTable("tblOrder");

            modelBuilder.Entity<Material>().HasKey(material => material.MaterialId).HasName("MaterialId");
            modelBuilder.Entity<OrderStatus>().HasKey(orderStatus => orderStatus.OrderStatusId).HasName("OrderStatusId");
            modelBuilder.Entity<Order>().HasKey(order => order.OrderId).HasName("OrderId");

            modelBuilder.Entity<Material>().Property(material => material.MaterialId).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<Material>().Property(material => material.MaterialName).HasColumnType("varchar(50)");
            modelBuilder.Entity<Material>().Property(material => material.CreatedBy).HasColumnType("varchar(50)");
            modelBuilder.Entity<Material>().Property(material => material.CreateDate).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Material>().Property(material => material.UpdatedBy).HasColumnType("varchar(50)");
            modelBuilder.Entity<Material>().Property(material => material.UpdateDate).HasColumnType("datetime");

            modelBuilder.Entity<OrderStatus>().Property(orderStatus => orderStatus.OrderStatusId).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<OrderStatus>().Property(orderStatus => orderStatus.OrderStatusDescription).HasColumnType("varchar(50)");
            modelBuilder.Entity<OrderStatus>().Property(orderStatus => orderStatus.CreatedBy).HasColumnType("varchar(50)");
            modelBuilder.Entity<OrderStatus>().Property(orderStatus => orderStatus.CreateDate).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<OrderStatus>().Property(orderStatus => orderStatus.UpdatedBy).HasColumnType("varchar(50)");
            modelBuilder.Entity<OrderStatus>().Property(orderStatus => orderStatus.UpdateDate).HasColumnType("datetime");

            modelBuilder.Entity<Order>().Property(order => order.OrderId).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.CustomerOrderId).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.OriginAddress).HasColumnType("varchar(500)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.DestinationAddress).HasColumnType("varchar(500)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.MaterialQuantity).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.QuantityUnit).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.TotalWeight).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.WeightUnit).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.MaterialId).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.OrderStatusId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.Note).HasColumnType("varchar(500)").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.CreatedBy).HasColumnType("varchar(50)");
            modelBuilder.Entity<Order>().Property(order => order.CreateDate).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.UpdatedBy).HasColumnType("varchar(50)");
            modelBuilder.Entity<Order>().Property(order => order.UpdateDate).HasColumnType("datetime");
        }
    }
}
