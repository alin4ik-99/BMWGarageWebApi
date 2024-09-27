using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.ViewModels
{
    public class CarRepairVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name of service")]
        public string TypeOfCarRepair { get; set; }

        [Required]
        [Display(Name = "Minimum price")]
        public decimal PriceMin { get; set; }

        [Required]
        [Display(Name = "Maximum price")]
        public decimal PriceMax { get; set; }
    }
}
