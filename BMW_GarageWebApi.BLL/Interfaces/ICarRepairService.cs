using BMW_GarageWebApi.Domain.DTOModels.DTOCarRepair;
using BMW_GarageWebApi.Domain.Models;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface ICarRepairService
    {
        IEnumerable<CarRepairDTO> GetAllCarRepair();
        CarRepairDTO GetCarRepair(int id);
        void RemoveCarRepair(int id);
        void AddCarRepair(CarRepairDTO objDTO);
        void UpdateCarRepair(CarRepairDTO objDTO);
    }
}
