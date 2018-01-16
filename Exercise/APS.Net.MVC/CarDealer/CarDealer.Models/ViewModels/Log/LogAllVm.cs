﻿using System;
using CarDealer.Models.EntityModels;

namespace CarDealer.Models.ViewModels.Log
{
    public class LogAllVm
    {
        public string UserName { get; set; }

        public OperationLog Operation { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModfiedTable { get; set; }
    }
}