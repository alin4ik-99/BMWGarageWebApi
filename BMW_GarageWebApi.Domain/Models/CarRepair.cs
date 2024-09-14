using BMW_GarageWebApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.Domain.Models
{
    public class CarRepair
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва послуги")]
        public string TypeOfCarRepair { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Мінімальна ціна")]
        public double PriceFrom { get; set; }


        [Required]
        [Display(Name = "Максимальна ціна")]
        public double PriceTo { get; set; }
    }
}
