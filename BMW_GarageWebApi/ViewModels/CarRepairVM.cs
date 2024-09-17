using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.ViewModels
{
    public class CarRepairVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва послуги")]
        public string TypeOfCarRepair { get; set; }

        [Required]
        [Display(Name = "Мінімальна ціна")]
        public decimal PriceMin { get; set; }

        [Required]
        [Display(Name = "Максимальна ціна")]
        public decimal PriceMax { get; set; }
    }
}
