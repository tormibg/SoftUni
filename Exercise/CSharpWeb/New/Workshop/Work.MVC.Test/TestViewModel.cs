﻿using System.Collections.Generic;

namespace Work.MVC.Test
{
    public class TestViewModel
    {
        public int Year { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> Numbers { get; set; }
    }
}