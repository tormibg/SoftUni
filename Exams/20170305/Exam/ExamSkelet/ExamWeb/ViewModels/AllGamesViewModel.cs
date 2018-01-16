namespace SoftUniStore.App.ViewModels
{
    public class AllGamesViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ImageThumbnail { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            //string template = $@"<div class=""card col-4 thumbnail"">
            //            <img class=""card-image-top img-fluid img-thumbnail"" src=""{this.ImageThumbnail}"">
            //            <div class=""card-block"">
            //                <h4 class=""card-title"">{this.Title}</h4>
            //                <p class=""card-text""><strong>Price</strong> - {this.Price} &euro;</p>
            //                <p class=""card-text""><strong>Size</strong> - {this.Size}0 GB</p>
            //                <p class=""card-text"">{this.Description}</p>
            //            </div>
            //            <div class=""card-footer"">
            //                <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/game/gamedetails?gameid={this.Id}"">Info</a>
            //            </div>";
            //      //  </div>

            string template = $@"<div class=""card col-4 thumbnail"">

                        <img class=""card-image-top img-fluid img-thumbnail"" src=""{this.ImageThumbnail}"">

                        <div class=""card-block"">
                            <h4 class=""card-title"">{this.Title}</h4>
                            <p class=""card-text""><strong>Price</strong> - {this.Price}&euro;</p>
                            <p class=""card-text""><strong>Size</strong> - {this.Size} GB</p>
                            <p class=""card-text"">{this.Description}</p>
                        </div>

                        <div class=""card-footer"">
                            <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/game/gamedetails?gameid={this.Id}"">Info</a>
                        </div>

                    </div>";

            return template;
        }
    }
}