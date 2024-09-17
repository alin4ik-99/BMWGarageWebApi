

using BMW_GarageWebApi.Domain.Models;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface ICarRecordService
    {
        IEnumerable<CarRecord> GetAllCarRecord();
        CarRecord GetCarRecord(int id);
        void RemoveCarRecord(int id);
        void AddCarRecord(CarRecord entity);
        void UpdateCarRecord(CarRecord entity);
    }
}
