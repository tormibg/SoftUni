﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        [Range(1,int.MaxValue)]
        public int AccountNumber { get; set; }

        [Required]
        public DateTime FirstDateOccupied { get; set; }

        [Required]
        public DateTime LastDateOccupied { get; set; }

        [Range(1,int.MaxValue)]
        public int TotalDays { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal AmountCharged { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal TaxRate { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal TaxAmount { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal PaymentTotal { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}