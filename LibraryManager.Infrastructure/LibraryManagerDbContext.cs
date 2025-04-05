using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryManager.Infrastructure
{
    public class LibraryManagerDbContext : DbContext
    {
        public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BooksCategories> BooksCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(LibraryManagerDbContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }

            modelBuilder.Entity<BooksCategories>(entity =>
            {
                entity.HasKey(bc => new { bc.BookId, bc.CategoryId });

                entity.HasOne(bc => bc.Book)
                    .WithMany(b => b.Categories)
                    .HasForeignKey(bc => bc.BookId);

                entity.HasOne(bc => bc.Category)
                    .WithMany(c => c.BooksCategories)
                    .HasForeignKey(bc => bc.CategoryId);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasOne(l => l.User)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(l => l.UserId);

                entity.HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId);
            });
        }

        private static void SetSoftDeleteFilter<TEntity>(ModelBuilder modelBuilder)
            where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
