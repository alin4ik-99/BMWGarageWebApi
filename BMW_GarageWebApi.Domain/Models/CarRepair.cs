﻿using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.Domain.Models
{
    public class CarRepair
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeOfCarRepair { get; set; }

        [Required]
        public decimal PriceMin { get; set; }

        [Required]
        public decimal PriceMax { get; set; }
    }
}
