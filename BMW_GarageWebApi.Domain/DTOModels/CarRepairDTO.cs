using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.Domain.DTOModels
{
    public class CarRepairDTO
    {
        public int Id { get; set; }

        public string TypeOfCarRepair { get; set; }

        public decimal PriceMin { get; set; }

        public decimal PriceMax { get; set; }
    }
}
