using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Services
{
    public class CarRepairService : ICarRepairService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarRepairService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCarRepair(CarRepair entity)
        {
            _unitOfWork.CarRepair.Add(entity);
        }

        public IEnumerable<CarRepair> GetAllCarRepair()
        {
            var objCarRepairList = _unitOfWork.CarRepair.GetAll();
            return objCarRepairList;
        }

        public CarRepair GetCarRepair(int id)
        {
            var carRepairFromDb = _unitOfWork.CarRepair.Get(u => u.Id == id);
            return carRepairFromDb;
        }

        public void RemoveCarRepair(int id)
        {
            var carRepairFromDb = _unitOfWork.CarRepair.Get(u => u.Id == id);          
            _unitOfWork.CarRepair.Remove(carRepairFromDb);
        }

        public void UpdateCarRepair(CarRepair entity)
        {
            _unitOfWork.CarRepair.Update(entity);
        }
    }
}
