using BMW_GarageWebApi.Domain.DTOModels.DTOCarRepair;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface ICarRepairService
    {
        Task<IEnumerable<CarRepairDTO>> GetAllCarRepair();
        Task<CarRepairDTO> GetCarRepair(int id);
        Task RemoveCarRepair(int id);
        Task AddCarRepair(CarRepairDTO objDTO);
        Task UpdateCarRepair(CarRepairDTO objDTO);
    }
}
