using System.Collections.Generic;
using iRunes.Models;
using iRunes.ViewModels.Albums;

namespace iRunes.Services
{
    public interface IAlbumsService
    {
        void Create(string cover, string name);
        IEnumerable<AlbumInfoViewModel> GetAllAlbums();
        AlbumDetailsViewModel GetAlbumDetails(string id);
    }
}