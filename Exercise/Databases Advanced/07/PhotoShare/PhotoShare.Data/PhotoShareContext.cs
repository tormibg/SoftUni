using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using PhotoShare.Data.Migrations;
using PhotoShare.Models;

namespace PhotoShare.Data
{
    public class PhotoShareContext : DbContext
    {
        public PhotoShareContext() : base("name=PhotoShareContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoShareContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<AlbumRole> AlbumRoles { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UsersFriends");
                }
                );
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                // Throw a new DbEntityValidationException with the improved exception message.
                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                throw new Exception(exceptionMessage);
            }
        }
    }
}