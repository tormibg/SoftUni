using System;
using System.Collections.Generic;
using System.Dynamic;
using SoftUniStore.App.Model;
using SoftUniStore.App.Views.Store;

namespace SoftUniStore.App.ViewModels
{
    public class GameDatailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        //public string ImageThumbnail { get; set; }

        public float Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public List<User> Owners { get; set; }

        public int curUserId { get; set; }

        public override string ToString()
        {
            //string template =
            //    $@"<h1 class=""display-3"">{this.Title}</h1>
            //    <br/>
            //    <iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/{this.Trailer}"" frameborder=""0"" allowfullscreen></iframe>
            //                <br/>
            //                <br/>
            //                <p>{this.Description}</p>

            //                <p><strong>Price</strong> - {this.Price} &euro;</p>
            //                <p><strong>Size</strong> - {this.Size} GB</p>
            //                <p><strong>Release Date</strong> - {this.ReleaseDate}</p>
            //                <a class=""btn btn-outline-primary"" name=""back"" href=""/store/all"">Back</a>
            //                <form action="""" method=""Post"">
            //                <input type=""number"" name=""userid"" value=""{this.curUserId}"" hidden=""hidden""/>
            //                <input type=""number"" name=""gameid"" value=""{this.Id}"" hidden=""hidden"">
            //                <br/>
            //                <input type=""submit"" class=""btn btn-success"" value=""Buy"" />"; //TODO

            string template =
                $@"<h1 class=""display-3"">{this.Title}</h1>
                <br/>
                <iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/{this.Trailer}"" frameborder=""0"" allowfullscreen></iframe>
                            <br/>
                            <br/>
                            <p>{this.Description}</p>

                            <p><strong>Price</strong> - {this.Price} &euro;</p>
                            <p><strong>Size</strong> - {this.Size} GB</p>
                            <p><strong>Release Date</strong> - {this.ReleaseDate}</p>
                            <a class=""btn btn-outline-primary"" name=""back"" href=""/store/all"">Back</a>
                            <input type=""number"" name=""userid"" value=""{this.Owners}"" hidden=""hidden""/>
                            <input type=""number"" name=""gameid"" value=""{this.Id}"" hidden=""hidden"">";
                            
            return template;
        }
    }
}