using System;

namespace SoftUniStore.App.ViewModels
{
    public class GameEditViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public float Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        //public DateTime? ReleaseDate { get; set; }

        public override string ToString()
        {
            string template =$@" <input type=""type"" hidden=""hidden"" value=""2"" />

                                <div class=""form-group row"">
                                <label for=""name"" class=""form-control-label"">Title</label>
                                <input name=""title"" type=""text"" maxlength=""100"" minlength=""4"" id=""name"" class=""form-control""
                               placeholder=""Enter Game Name"" value=""{this.Title}""/>
                                </div>

                                <div class=""form-group row"">
                                <label for=""desc"" class=""form-control-label"">Description</label>
                                <textarea name=""description"" id=""desc"" class=""form-control""
                                  placeholder=""Enter Game Description"" minlength=""30"">{this.Description}</textarea>
                                </div>

                                <div class=""form-group row"">
                                <label for=""thumbnail"" class=""form-control-label"">Thumbnail</label>
                                <input name=""imagethumbnail"" type=""url"" id=""thumbnail"" class=""form-control""
                               placeholder=""Enter URL to Image""
                               value=""{this.ImageThumbnail}g""/>
                                </div>

                                <div class=""form-group row"">
                                <label for=""price"" class=""form-control-label"">Price</label>
                                <div class=""input-group"">

                                <input name=""price"" type=""number"" step=""0.01"" min=""0"" id=""price"" class=""form-control""
                                   placeholder=""Enter Price"" value=""{this.Price}""/>
                                <span class=""input-group-addon""
                                  id=""addon2"">&euro;</span>
                                </div>
                                </div>

                                <div class=""form-group row"">
                                <label for=""size"" class=""form-control-label"">Size</label>
                                <div class=""input-group"">

                                <input name=""size"" type=""number"" step=""0.1"" min=""0"" id=""size"" class=""form-control""
                                   placeholder=""Enter Size"" value=""{this.Size}""/>
                                <span class=""input-group-addon""
                                  id=""addon3"">GB</span>
                                </div>
                                </div>

                                <div class=""form-group row"">
                                <label for=""video"" class=""form-control-label"">YouTube Video URL</label>
                                <div class=""input-group"">
                                <span class=""input-group-addon""
                                  id=""addon"">https://www.youtube.com/watch?v=</span>
                                <input name=""trailer"" type=""text"" class=""form-control"" id=""video""
                                   value=""{this.Trailer}""/>
                                </div>
                                </div>
                                <input type=""submit"" id=""btn-edit-game"" class=""btn btn-outline-warning btn-lg btn-block""
                                value=""Edit Game""/>
                                <input type=""number"" name=""id"" value=""{this.Id}"" hidden=""hidden"">
                                ";

            return template;
        }
    }
}