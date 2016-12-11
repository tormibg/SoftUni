using System;
using System.Data.Entity.Validation;
using System.Linq;
using CreateUser.Models;

namespace CreateUser
{
    class CreateUser
    {
        static void Main()
        {
            var context = new UsersContext();
            context.Database.Initialize(true);

            //string emailProvider = Console.ReadLine();

            //var result = context.Users.Where(u => u.Email.EndsWith(emailProvider));
            //foreach (var user in result)
            //{
            //    Console.WriteLine($"{user.Username} {user.Email}");
            //}

            //int pixsels = int.Parse(Console.ReadLine());
            //int count = 0;

            //var result = context.Users.Where(u => u.ProfilePicture != null);

            //foreach (var user in result)
            //{
            //    if (user.MyImage.Width > pixsels)
            //    {
            //        count++;
            //    }
            //}

            //Console.WriteLine(
            //    $"{(count == 0 ? "No" : count.ToString())} users have profile pictures wider than {pixsels} pixels");

            //string enteredDateString = Console.ReadLine();
            //DateTime enteredDate = DateTime.Parse(enteredDateString);

            //var usersForDeleted = context.Users.Where(u => u.LastTimeLoggedIn < enteredDate && !u.IsDeleted).ToList();
            //foreach (var user in usersForDeleted)
            //{
            //    user.IsDeleted = true;
            //}

            //Console.WriteLine(usersForDeleted.Count == 0
            //    ? "No users have been deleted"
            //    : $"{usersForDeleted.Count} user has been deleted");

            //context.SaveChanges();

            //ReceivedTags(context);

            context.AddOwnAlbumToUser(context.Users.First(), new Album()
            {
                IsPublic = true,
                Name = "SomeNames"
            });
            context.SaveChanges();

            context.AddPublicAlbumForUser(context.Users.First(), new Album()
            {
                IsPublic = true,
                Name = "Non public"
            });

            context.SaveChanges();

            var albums = context.GetPublicAlbumForUsers(context.Users.First());
            foreach (var album in albums)
            {
                Console.WriteLine(album.Name);
            }
        }

        private static void ReceivedTags(UsersContext context)
        {
            string inputStr = Console.ReadLine();

            Tag tag = new Tag()
            {
                Name = inputStr
            };

            try
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                tag.Name = TagTransofrmer.Transform(tag.Name);
                context.SaveChanges();
            }
        }
    }
}
