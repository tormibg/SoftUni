namespace SoftUniStore.App.ViewModels
{
    public class AllGamesListViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; } 

       // public string Trailer { get; set; } 

        //public string ImageThumbnail { get; set; } 

        public string Size { get; set; } 

        public decimal Price { get; set; } 

       // public string Description { get; set; } 

        public override string ToString()
        {
            string template = $@"<tr>
                                <td>{this.Title}</td>
                                <td>{this.Size} GB</td>
                                <td>{this.Price} &euro;</td>
                                <td>
                                <a href=""/game/editgame?gameid={this.Id}"" class=""btn btn-warning btn-sm"">Edit</a>
                                <a href=""/game/deletegame?gameid={this.Id}"" class=""btn btn-danger btn-sm"">Delete</a>
                                </td>
                                </tr>";

            return template;
        }
    }
}