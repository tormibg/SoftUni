using System.Security.Cryptography.X509Certificates;
using Models;

namespace Data
{
    using System.Data.Entity;

    public class BookShopContext : DbContext
    {

        public BookShopContext()
            : base("name=BookShopContext")
        {
        }

        public DbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithMany(b => b.Categories)
                .Map(x => x.MapRightKey("BookId").MapLeftKey("CategorieId"));

            modelBuilder.Entity<Book>().HasMany(b => b.RelatedBooks).WithMany().Map(m =>
            {
                m.MapLeftKey("BookId");
                m.MapRightKey("RelatedBookId");
                m.ToTable("BooksRelatedBooks");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}