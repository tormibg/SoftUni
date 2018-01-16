using System;

namespace SoftUniStore.App.BindingModels
{
    public class EditGameBindingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; } 

        public float Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}