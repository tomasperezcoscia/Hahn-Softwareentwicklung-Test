using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


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
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(t => t.BuyerId);
            });
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(t => t.WorkerId);
            });
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(t => t.CarID);
            });
            modelBuilder.Entity<Inquiry>().ToTable("Inquiries");
            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.HasKey(t => t.InquiryID);
            });
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(t => t.OrderId);
            });
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(t => t.PaymentId);
            });
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(t => t.PaymentMethodId);
            });
            modelBuilder.Entity<ShippingAddress>().ToTable("ShippingAddresses");
            modelBuilder.Entity<ShippingAddress>(entity =>
            {
                entity.HasKey(t => t.ShippingAddressId);
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }


    }
}

