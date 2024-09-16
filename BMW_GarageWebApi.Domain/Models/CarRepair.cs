using System.ComponentModel.DataAnnotations;

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
        public decimal PriceMin { get; set; }

        [Required]
        [Display(Name = "Максимальна ціна")]
        public decimal PriceMax { get; set; }
    }
}
