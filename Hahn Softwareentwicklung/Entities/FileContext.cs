using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace Hahn_Softwareentwicklung.Entities
{
    public class FileContext : DbContext
    {
        public FileContext() { }

        public FileContext(DbContextOptions<FileContext> options)
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
            modelBuilder.Entity<FileTrafic>().ToTable("Files");
            modelBuilder.Entity<FileTrafic>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FileTrafic> Files { get; set; }
    }
}
