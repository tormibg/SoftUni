using iRunes.Controllers;

namespace iRunes.Services
{
    public interface ITracksService
    {
        void Create(string inputAlbumId, string inputName, in decimal inputPrice, string inputLink);
        DetailsVieModel GetDetails(string trackId);
    }
}