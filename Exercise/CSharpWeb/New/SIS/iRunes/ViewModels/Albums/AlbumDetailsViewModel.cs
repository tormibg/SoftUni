﻿using System.Collections.Generic;

namespace iRunes.ViewModels.Albums
{
    public class AlbumDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }
    }
}