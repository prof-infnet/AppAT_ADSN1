using AppAT.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AppAT.DAL.Data
{
    public class AppATContext : DbContext
    {

        public  AppATContext(DbContextOptions<AppATContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(t => new { t.AuthorId, t.BookId });

            modelBuilder.Entity<AuthorBook>()
                .HasOne(t => t.Author)
                .WithMany(t => t.AuthorBook)
                .HasForeignKey(t => t.AuthorId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(t => t.Book)
                .WithMany(t => t.AuthorBook)
                .HasForeignKey(t => t.BookId);

        }




    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppATContext>
    {
        public AppATContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory()
      + "/../AppAT.API/appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<AppATContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new AppATContext(builder.Options);
        }
    }
}
