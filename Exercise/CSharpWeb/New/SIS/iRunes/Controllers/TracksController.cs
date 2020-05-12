using iRunes.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace iRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            var viewModel = new CreateTrackAlbumVewModel
            {
                AlbumId = albumId
            };
            return this.View(viewModel);
        }
        [HttpPost]
        public HttpResponse Create(CreateTrackPostVewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name min 4, max 20");
            }

            tracksService.Create(input.AlbumId, input.Name, input.Price, input.Link);
            return this.Redirect("/Albums/Details?id="+input.AlbumId);
        }

        public HttpResponse Details(string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = tracksService.GetDetails(trackId);
            return this.View(viewModel);
        }
    }
}