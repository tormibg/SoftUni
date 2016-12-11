using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Models;

namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Data.BookShopContext";
        }

        protected override void Seed(Data.BookShopContext context)
        {
            var random = new Random();
            //using (var reader = new StreamReader("c:\\temp\\authors.txt"))
            //{
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //        var firstName = data[0];
            //        var lastNames = data[1];
            //        context.Authors.Add(new Author()
            //        {
            //            FirstName = firstName,
            //            LastName = lastNames
            //        });
            //        line = reader.ReadLine();
            //    }
            //}

            //using (var reader = new StreamReader("c:\\temp\\books.txt"))
            //{
            //    var authors = context.Authors.ToList();
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(new[] { ' ' }, 6);
            //        var authorIndex = random.Next(0, authors.Count);
            //        var author = authors[authorIndex];
            //        var edition = (EditionType)int.Parse(data[0]);
            //        var releaseData = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
            //        var copies = int.Parse(data[2]);
            //        var pricw = decimal.Parse(data[3]);
            //        var ageRestriction = (AgeRestriction)int.Parse(data[4]);
            //        var title = data[5];
            //        var category = context.Categories.ToArray();
            //        var categList = new HashSet<Category>()
            //        {
            //            category[random.Next(0, category.Length)],
            //            category[random.Next(0, category.Length)],
            //            category[random.Next(0, category.Length)]
            //        };

            //        context.Books.Add(new Book()
            //        {
            //            Author = author,
            //            Edition = edition,
            //            ReleaseDateTime = releaseData,
            //            Copies = copies,
            //            Price = pricw,
            //            AgeRestriction = ageRestriction,
            //            Title = title,
            //            Categories = categList
            //        });
            //        line = reader.ReadLine();
            //    }
            //}

            //using (var reader = new StreamReader("c:\\temp\\categories.txt"))
            //{
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var name = line.Trim();
            //        var books = context.Books.ToArray();
            //        HashSet<Book> booksToAdd = new HashSet<Book>()
            //        {
            //            books[random.Next(1, books.Length)],
            //            books[random.Next(1, books.Length)],
            //            books[random.Next(1, books.Length)]
            //        };
            //        context.Categories.Add(new Category()
            //        {
            //            Name = name,
            //            Books = booksToAdd
            //        });
            //        line = reader.ReadLine();
            //    }
            //}
        }
    }
}
