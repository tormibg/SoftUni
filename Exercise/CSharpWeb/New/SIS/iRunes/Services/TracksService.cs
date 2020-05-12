using System.Linq;
using System.Security.Cryptography.X509Certificates;
using iRunes.Controllers;
using iRunes.Models;

namespace iRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string inputAlbumId, string inputName, in decimal inputPrice, string inputLink)
        {
            var track = new Track
            {
                AlbumId = inputAlbumId,
                Link = inputLink,
                Name = inputName,
                Price = inputPrice
            };
            this.db.Tracks.Add(track);
            decimal allTrackPricesSum = this.db.Tracks.Where(x => x.AlbumId == inputAlbumId).Sum(s => s.Price) + inputPrice;
            var album = this.db.Albums.Find(inputAlbumId);
            album.Price = allTrackPricesSum * (decimal) 0.87;
            db.SaveChanges();
        }

        public DetailsVieModel GetDetails(string trackId)
        {
            var track = this.db.Tracks.Where(x => x.Id == trackId).Select(x => new DetailsVieModel()
            {
                AlbumId = x.AlbumId,
                Name = x.Name,
                Link = x.Link,
                Price = x.Price
            }).FirstOrDefault();
            return track;
        }
    }
}