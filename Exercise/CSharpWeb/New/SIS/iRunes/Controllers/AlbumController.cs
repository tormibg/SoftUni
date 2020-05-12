using iRunes.Services;
using iRunes.ViewModels.Albums;
using SIS.HTTP;
using SIS.MvcFramework;

namespace iRunes.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewAlbums = new AlbumsInfoViewModel()
            {
                Albums = this.albumsService.GetAllAlbums()
            };
            return this.View(viewAlbums);
        }

        public HttpResponse Create()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(CreateInputModel createInputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (createInputModel.Name.Length < 4 || createInputModel.Name.Length > 20)
            {
                return this.Error("Name min 4, max 20");
            }

            if (string.IsNullOrWhiteSpace(createInputModel.Cover))
            {
                return this.Error("Cover is required");
            }

            this.albumsService.Create(createInputModel.Cover, createInputModel.Name);
            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var albums = albumsService.GetAlbumDetails(id);
            return this.View();
        }
    }
}