using CustomerOrdersAPI.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrdersAPI.EntityFramework
{
    /// <summary>
    /// Defines the <see cref="CustomerOrdersDbContext" />.
    /// </summary>
    public class CustomerOrdersDbContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrdersDbContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{CustomerOrdersDbContext}"/>.</param>
        public CustomerOrdersDbContext(DbContextOptions<CustomerOrdersDbContext> options) : base(options)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Materials.
        /// </summary>
        public DbSet<Material> Materials { get; set; }

        /// <summary>
        /// Gets or sets the Orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatuses.
        /// </summary>
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
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

        #endregion
    }
}
