using BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface ICarRecordService
    {
        Task<IEnumerable<CarRecordDTO>> GetAllCarRecord();
        Task<IEnumerable<CarRecordDTO>> GetAllCarRecordUser(string userId);
        Task<CarRecordDTO> GetCarRecord(int id);
        Task RemoveCarRecord(int id);
        Task AddCarRecord(CarRecordDTO objDTO);
        Task UpdateCarRecord(CarRecordDTO objDTO);
    }
}
