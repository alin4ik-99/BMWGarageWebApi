using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Services
{
    public class CarRecordService : ICarRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCarRecord(CarRecord entity)
        {
            _unitOfWork.CarRecord.Add(entity);
        }

        public IEnumerable<CarRecord> GetAllCarRecord()
        {
            var objCarRecordList = _unitOfWork.CarRecord.GetAll(includeProperties: "Employee");
            return objCarRecordList;
        }

        public CarRecord GetCarRecord(int id)
        {
            var carRecordFromDb = _unitOfWork.CarRecord.Get(u => u.Id == id);
            return carRecordFromDb;
        }

        public void RemoveCarRecord(int id)
        {
            var carRecordFromDb = _unitOfWork.CarRecord.Get(u => u.Id == id);
            _unitOfWork.CarRecord.Remove(carRecordFromDb);
        }

        public void UpdateCarRecord(CarRecord entity)
        {
            _unitOfWork.CarRecord.Update(entity);
        }
    }
}
