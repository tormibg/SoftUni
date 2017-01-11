﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class Occupancy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOccupied { get; set; }

        [Range(1,int.MaxValue)]
        public int AccountNumber { get; set; }

        [Range(1,int.MaxValue)]
        public int RoomNumber { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal RateApplied { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal PhoneCharge { get; set; }
        
        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}