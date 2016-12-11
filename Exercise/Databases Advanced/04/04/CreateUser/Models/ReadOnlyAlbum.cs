using System.Collections.Generic;

namespace CreateUser.Models
{
    public class ReadOnlyAlbum
    {
        public ReadOnlyAlbum(Album album)
        {
            this.UserAlbums = (IReadOnlyCollection<UserAlbum>)album.UserAlbums;
            this.BackGroundColor = album.BackGroundColor;
            this.Id = album.Id;
            this.IsPublic = album.IsPublic;
            this.Name = album.Name;
            this.Pictures = (IReadOnlyCollection<Picture>)album.Pictures;
            this.Tags = (IReadOnlyCollection<Tag>)album.Tags;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackGroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual IReadOnlyCollection<Picture> Pictures { get; set; }

        public virtual IReadOnlyCollection<Tag> Tags { get; set; }

        public virtual IReadOnlyCollection<UserAlbum> UserAlbums { get; set; }
    }
}