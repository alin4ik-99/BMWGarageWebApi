using BMW_GarageWebApi.Domain.Models;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface ICarRepairService
    {
        IEnumerable<CarRepair> GetAllCarRepair();
        CarRepair GetCarRepair(int id);
        void RemoveCarRepair(int id);
        void AddCarRepair(CarRepair entity);
        void UpdateCarRepair(CarRepair entity);
    }
}
