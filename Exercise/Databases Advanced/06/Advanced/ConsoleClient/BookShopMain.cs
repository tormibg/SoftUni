using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Models;
using Data;
using EntityFramework.Extensions;

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

            //GetAllBooksWithRestrictions(context);

            //GetGoldenBooks(context);

            //GetBooksByPrice(context);

            //GetNotReleasedBooks(context);

            //GetBookTitlesByCategory(context);

            //GetBooksReleasedBeforeDate(context);

            //GetAuthorsByChars(context);

            //GetBooksByString(context);

            //GetBooksByAuthors(context);

            //GetCountOfBooks(context);

            //GetTotalBooksCopiesByAuthor(context);

            //GetProfitByCategory(context);

            //GetMostRecentBooks(context);

            //IncreaseBooksCopies(context);

            //RemoveBooks(context);

            StoredProcedure(context);
        }

        private static void StoredProcedure(BookShopContext context)
        {
            Console.Write("Please enter the first and last name of the author separated by a single space: ");
            string[] names = Console.ReadLine().Split(' ');
            SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.VarChar);
            SqlParameter lastName = new SqlParameter("@lastName", SqlDbType.VarChar);
            firstName.Value = names[0];
            lastName.Value = names[1];
            int numberOfBooksWritten = context.Database.SqlQuery<int>("TotalNumberOfBooksByAuthor @firstName, @lastName", firstName, lastName).Single();
            Console.WriteLine($"{firstName.Value} {lastName.Value} has written {numberOfBooksWritten} books");
        }

        private static void RemoveBooks(BookShopContext context)
        {
            var number = int.Parse(Console.ReadLine());
            var booksDeleted = context.Books.Where(b => b.Copies < number).Delete();
            context.SaveChanges();
            Console.WriteLine($"{booksDeleted} books were deleted");
        }

        private static void IncreaseBooksCopies(BookShopContext context)
        {
            var date = DateTime.ParseExact(Console.ReadLine()?.Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            var copies = int.Parse(Console.ReadLine());

            var count = context.Books.Count(b => b.ReleaseDateTime > date);
            Console.WriteLine(count*copies);
            var books = context.Books.Where(b => b.ReleaseDateTime > date)
                .Update(b => new Book() { Copies = b.Copies + copies }) /// Extend method
            ;
            //foreach (var book in books)
            //{
            //    book.Copies = book.Copies + copies;
            //}
            /// EF.Extended
            //context.Books.Update(books, b => new Book() {Copies = b.Copies + copies});
            context.SaveChanges();
        }

        private static void GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.Where(c => c.Books.Count > 35)
                .Select(
                    c =>
                        new
                        {
                            CategoryName = c.Name,
                            BooksCount = c.Books.Count,
                            RecentBooks =
                            c.Books.OrderByDescending(b => b.ReleaseDateTime)
                                .ThenBy(b => b.Title)
                                .Select(b => new { BookTitle = b.Title, BookReleaseDate = b.ReleaseDateTime })
                                .Take(3)
                        }).OrderByDescending(o => o.BooksCount);
            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.CategoryName}: {category.BooksCount} books");
                foreach (var book in category.RecentBooks)
                {
                    Console.WriteLine($"{book.BookTitle} ({book.BookReleaseDate.Year})");
                }
            }
        }

        private static void GetProfitByCategory(BookShopContext context)
        {
            var profitsByCategories = context.Categories
                .GroupBy(category => new
                    {
                        CategoryName = category.Name
                    }
                )
                .Select(g => new {Name = g.Key.CategoryName, Sum = g.Sum(c => c.Books.Sum(b => b.Price*b.Copies))})
                .OrderByDescending(o => o.Sum)
                .ThenBy(o => o.Name);

            foreach (var profitByCategory in profitsByCategories)
            {
                Console.WriteLine($"{profitByCategory.Name} - ${profitByCategory.Sum}");
            }
        }

        private static void GetTotalBooksCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors.GroupBy(a => new
            {
                FullName = a.FirstName + " " + a.LastName}).Select(a => new { FullName = a.Key.FullName, 
                Copies = a.Sum(s => s.Books.Sum(b => b.Copies))
            }).OrderByDescending(a => a.Copies);
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FullName} - {author.Copies}");
            }
        }

        private static void GetCountOfBooks(BookShopContext context)
        {
            var input = int.Parse(Console.ReadLine());
            var books = context.Books.Count(b => b.Title.Length > input);
            Console.WriteLine($"{books}");
        }

        private static void GetBooksByAuthors(BookShopContext context)
        {
            var input = Console.ReadLine().ToLower();
            var books =
                context.Books.Where(b => b.Author.LastName.StartsWith(input))
                    .Select(b => new {b.Title, FullName = b.Author.FirstName + " " + b.Author.LastName});
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.FullName})");
            }
        }

        private static void GetBooksByString(BookShopContext context)
        {
            var input = Console.ReadLine().ToLower();
            var books = context.Books.Where(b => b.Title.Contains(input)).Select(b => new {b.Title});
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }
        }

        private static void GetAuthorsByChars(BookShopContext context)
        {
            var input = Console.ReadLine();
            var authors =
                context.Authors.Where(a => a.FirstName.EndsWith(input)).Select(b => new {b.FirstName, b.LastName});
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        private static void GetBooksReleasedBeforeDate(BookShopContext context)
        {
            var input = Console.ReadLine().Trim();
            var dates = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books =
                context.Books.Where(b => b.ReleaseDateTime < dates).Select(b => new {b.Title, b.Edition, b.Price});
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Edition} - {book.Price}");
            }
        }

        private static void GetBookTitlesByCategory(BookShopContext context)
        {
            var input = Console.ReadLine();
            var data = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var books =
                context.Books.Where(b => b.Categories.Count(category => data.Contains(category.Name)) != 0)
                    .Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine($"{book}");
            }
        }

        private static void GetNotReleasedBooks(BookShopContext context)
        {
            var year = int.Parse(Console.ReadLine().Trim());
            var books = context.Books.Where(b => b.ReleaseDateTime.Year != year).Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine($"{book}");
            }
        }

        private static void GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Price < 5 || b.Price > 40).Select(b => new { b.Title, b.Price});
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Price}");
            }
        }

        private static void GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Edition == EditionType.Gold && b.Copies < 500).Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine($"{book}");
            }
        }

        private static void GetAllBooksWithRestrictions(BookShopContext context)
        {
            var input = Console.ReadLine().ToLower();
            var books = context.Books.Where(b => b.AgeRestriction.ToString().ToLower() == input).Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine($"{book}");
            }
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
