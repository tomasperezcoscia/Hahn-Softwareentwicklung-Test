using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Policy;
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
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<Menu>().ToTable("Menues");
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("Sqlite:Autoincrement", true);
            });
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            modelBuilder.Entity<MenuRole>().ToTable("MenuRole");
            modelBuilder.Entity<MenuRole>(entity =>
            {
                entity.HasKey(t => t.Id);
            });

            modelBuilder.Entity<Menu>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Menu>().HasData(
                            new Menu
                            {
                                Id = 1,
                                Name = "Dashboard",
                                Icon = "dashboard",
                                Url = "/pages/dashboard"
                            },
                            new Menu
                            {
                                Id = 2,
                                Name = "HR",
                                Icon = "assignment_ind",
                                Url = "/pages/humanresources"
                            },
                            new Menu
                            {
                                Id = 3,
                                Name = "Sales",
                                Icon = "attach_money",
                                Url = "/pages/sales"
                            },
                            new Menu
                            {
                                Id = 4,
                                Name = "Buyers",
                                Icon = "account_circle",
                                Url = "/pages/buyers"
                            },
                            new Menu
                            {
                                Id = 5,
                                Name = "Cars",
                                Icon = "directions_car",
                                Url = "/pages/cars"
                            },
                            new Menu
                            {
                                Id = 6,
                                Name = "LogOut",
                                Icon = "weekend",
                                Url = "/pages/logout"
                            },
                            new Menu
                            {
                                Id = 7,
                                Name = "LogIn",
                                Icon = "create",
                                Url = "/pages/login"
                            });

            modelBuilder.Entity<Role>().HasData(
                            new Role { Id = 1, Name = "Administrator", Description = "Administrator" },
                            new Role { Id = 2, Name = "HR", Description = "HumanResources employee" },
                            new Role { Id = 3, Name = "Sales", Description = "Sales employee" }
                            );

            modelBuilder.Entity<Worker>().HasData(
                            new Worker("Admin", "admin@admin.com", "123", 1, 999999, "admin123"),
                            new Worker("HR test", "hrtest@test.com", "123", 2, 0, "hrtest"),
                            new Worker("Sales test", "salestest@test.com", "123", 3, 0,"salestest")
                            );

            modelBuilder.Entity<MenuRole>().HasData(
                                new MenuRole { Id = 1, roleId = 1, menuId = 1 },
                                new MenuRole { Id = 2, roleId = 1, menuId = 2 },
                                new MenuRole { Id = 3, roleId = 1, menuId = 3 },
                                new MenuRole { Id = 4, roleId = 1, menuId = 4 },
                                new MenuRole { Id = 5, roleId = 1, menuId = 5 },
                                new MenuRole { Id = 6, roleId = 1, menuId = 6 },
                                new MenuRole { Id = 7, roleId = 1, menuId = 7 },
                                new MenuRole { Id = 8, roleId = 2, menuId = 1 },
                                new MenuRole { Id = 9, roleId = 2, menuId = 2 },
                                new MenuRole { Id = 10, roleId = 2, menuId = 6 },
                                new MenuRole { Id = 11, roleId = 2, menuId = 7 },
                                new MenuRole { Id = 12, roleId = 3, menuId = 1 },
                                new MenuRole { Id = 13, roleId = 3, menuId = 3 },
                                new MenuRole { Id = 14, roleId = 3, menuId = 4 },
                                new MenuRole { Id = 15, roleId = 3, menuId = 5 },
                                new MenuRole { Id = 16, roleId = 3, menuId = 6 },
                                new MenuRole { Id = 17, roleId = 3, menuId = 7 }
                            );
            modelBuilder.Entity<Car>().HasData(
                new Car("Ford","Fiesta",2018,1500,"Red"),
                new Car("Ford", "Focus", 2022, 3000, "Blue"),
                new Car("Nissan", "GTR 34", 2002, 150000, "Blue")
                );

            modelBuilder.Entity<PaymentMethod>().HasData(
                    new PaymentMethod { Id=1 ,Name = "None" },
                    new PaymentMethod { Id=2 , Name = "CreditCard" },
                    new PaymentMethod { Id=3 ,Name = "DebitCard" },
                    new PaymentMethod { Id=4 ,Name = "NetBanking" },
                    new PaymentMethod { Id=5, Name = "UPI" },
                    new PaymentMethod { Id = 6, Name = "Cash"}
                   );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Menu> Menues { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MenuRole> MenuRoles { get; set; }



    }
}

