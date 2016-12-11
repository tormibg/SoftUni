using System;
using System.Data.Entity;
using System.Linq;
using Models;
using Data;

namespace ConsoleClient
{
    class BookShopMain
    {
        static void Main()
        {
            var context = new BookShopContext();
            //context.Database.Initialize(true);
            //var bookCount = context.Books.Count();
            //Console.WriteLine(bookCount);

            var migrationStrategy = new DropCreateDatabaseIfModelChanges<BookShopContext>();

            Database.SetInitializer(migrationStrategy);

            //GetBooksAfter2000(context);

            //GetAuthorsWithBookIn1990(context);

            //GetAuthorsOrderByNumberOfBooks(context);

            //GetAllBookFromAuthor(context);

            //GetBooksByCategories(context);

            //var books = context.Books.Take(3).ToList();
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //context.SaveChanges();

            //var booksFromQuery = context.Books.Take(3);

            //foreach (var book in booksFromQuery)
            //{
            //    Console.WriteLine("--{0}", book.Title);
            //    foreach (var relatedBook in book.RelatedBooks)
            //    {
            //        Console.WriteLine(relatedBook.Title);
            //    }
            //}
        }

        private static void GetBooksByCategories(BookShopContext context)
        {
            var categories = context.Categories.Where(c => c.Books.Count > 0).OrderByDescending(cat => cat.Books.Count).Select(cat => new
            {
                cat.Name,
                BookCount = cat.Books.Count,
                Books = cat.Books.OrderByDescending(b => b.ReleaseDateTime)
                    .ThenBy(b => b.Title)
                    .Take(3)
                    .Select(b => new { b.Title, b.ReleaseDateTime })
            });

            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.Name}: {category.BookCount} books");
                foreach (var book in category.Books)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDateTime.Year})");
                }
            }
        }

        private static void GetAllBookFromAuthor(BookShopContext context)
        {
            var books =
                context.Books.Where(b => b.Author.FirstName + " "+ b.Author.LastName == "George Powell")
                    .OrderByDescending(b => b.ReleaseDateTime)
                    .ThenBy(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} {book.ReleaseDateTime} {book.Copies}");
            }
        }

        private static void GetAuthorsOrderByNumberOfBooks(BookShopContext context)
        {
            var authors =
                context.Authors.GroupBy(a => new {a.Books.Count}).OrderByDescending(b => b.Key.Count);

            foreach (var author in authors)
            {
                foreach (var author1 in author)
                {
                    Console.WriteLine($"{author1.FirstName} {author1.LastName} - {author.Key.Count}");
                }
            }
        }

        private static void GetAuthorsWithBookIn1990(BookShopContext context)
        {
            var authors = context.Authors.Where(a => a.Books.Count(b => b.ReleaseDateTime.Year < 1990) != 0);
            foreach (var author in authors)
            {
                foreach (var book in author.Books)
                {
                    Console.WriteLine($"{author.FirstName} {author.LastName} - {book.ReleaseDateTime.Year}");
                }
                
            }
        }

        private static void GetBooksAfter2000(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDateTime.Year > 2000);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.ReleaseDateTime.Year}");
            }
        }
    }
}
