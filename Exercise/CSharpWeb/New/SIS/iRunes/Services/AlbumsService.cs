using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using iRunes.Models;
using iRunes.ViewModels.Albums;

namespace iRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string cover, string name)
        {
            var album = new Album()
            {
                Cover = cover,
                Name = name,
                Price = 0.0M,
            };
            db.Albums.Add(album);
            db.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAllAlbums()
        {
            var albums = db.Albums.Select(x => new AlbumInfoViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return albums;
        }

        public AlbumDetailsViewModel GetAlbumDetails(string id)
        {
            var album = db.Albums.Where(x => x.Id == id).Select(x => new AlbumDetailsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Cover = x.Cover,
                Price = x.Price,
                Tracks = x.Tracks.Select(t => new TrackInfoViewModel { Id = t.Id, Name = t.Name})
            }).FirstOrDefault();
            return album;
        }
    }
}