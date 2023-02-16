using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

/*I will use only one DbContext since the app is kind of small at the moment, in case of it being bigger, i should divide it in one Context per Module
 * , (Customer Managemment, Sales, Shipping, Financing, etc) */

namespace Hahn_Softwareentwicklung.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(connectionString: "Filename=app.db",
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                    );
                });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(t => t.OrderId);
            });
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(t => t.OrderItemId);
            });
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(t => t.CarID);
            });
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(t => t.BuyerId);
            });
            modelBuilder.Entity<Buyer>()
                .HasMany(b => b.Orders)
                .WithOne(o => o.Buyer)
                .HasForeignKey(o => o.BuyerId);

            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(t => t.PaymentId);
            });
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(t => t.WorkerId);
            });
            
            


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }


    }
}

