

using BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord;
using BMW_GarageWebApi.Domain.Models;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface ICarRecordService
    {
        IEnumerable<CarRecordDTO> GetAllCarRecord();
        CarRecordDTO GetCarRecord(int id);
        void RemoveCarRecord(int id);
        void AddCarRecord(CarRecordDTO objDTO);
        void UpdateCarRecord(CarRecordDTO objDTO);
    }
}
