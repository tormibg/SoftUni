using System.Collections.Generic;
using CreateUser.Migrations;
using CreateUser.Models;

namespace CreateUser
{
    using System.Data.Entity;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<UsersContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UsersContext, Configuration>());
            //Database.Initialize(true);
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Town> Towns { get; set; }
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Picture> Pictures { get; set; }
        public IDbSet<Tag> Tags { get; set; }

        public ICollection<Album> GetOwnAlbumsForUsers(User user)
        {
            ICollection<Album> ownAlbums = new List<Album>();
            foreach (var album in user.UserAlbums)
            {
                if (album.UserRole == "Owner")
                {
                    ownAlbums.Add(album.Album);
                }
            }

            return ownAlbums;
        }

        public IReadOnlyCollection<ReadOnlyAlbum> GetPublicAlbumForUsers(User user)
        {
            ICollection<ReadOnlyAlbum> publicAlbums = new List<ReadOnlyAlbum>();
            foreach (var userAlbum in user.UserAlbums)
            {
                if (userAlbum.UserRole == "Viewer")
                {
                    publicAlbums.Add(new ReadOnlyAlbum(userAlbum.Album));
                }
            }
            return (IReadOnlyCollection<ReadOnlyAlbum>) publicAlbums;
        }

        public void AddOwnAlbumToUser(User user, Album album)
        {
            user.UserAlbums.Add(new UserAlbum()
            {
                Album = album,
                User = user,
                UserRole = "Owner"
            });
        }

        public void AddPublicAlbumForUser(User user, Album album)
        {
            user.UserAlbums.Add(new UserAlbum()
            {
                Album = album,
                User = user,
                UserRole = "Viewer"
            });
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ReadOnlyAlbum>();

            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany()
                .Map(conf =>
                {
                    conf.MapLeftKey("UserId");
                    conf.MapRightKey("FriendId");
                    conf.ToTable("UserFriends");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}