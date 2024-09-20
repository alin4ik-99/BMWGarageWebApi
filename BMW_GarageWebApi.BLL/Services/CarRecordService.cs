using AutoMapper;
using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BMW_GarageWebApi.BLL.Services
{
    public class CarRecordService : ICarRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        public void AddCarRecord(CarRecordDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRecord>(objDTO);
                _unitOfWork.CarRecord.Add(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding data", ex);
            }
        }

        public IEnumerable<CarRecordDTO> GetAllCarRecord()
        {
            try
            {
                var carRecordList = _unitOfWork.CarRecord.GetAll(includeProperties: "Employee");
                var carRecordListDTO = _mapper.Map<IEnumerable<CarRecordDTO>>(carRecordList);
                return carRecordListDTO;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"An error occurred while retrieving the data list", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the data list", ex);
            }
        }

        public CarRecordDTO GetCarRecord(int id)
        {
            try
            {
                var carRecord = _unitOfWork.CarRecord.Get(u => u.Id == id);
                var carRecordDTO = _mapper.Map<CarRecordDTO>(carRecord);
                return carRecordDTO;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"An error occurred while retrieving the CarRecord with id {id}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the CarRecord with id {id}.", ex);
            }
        }

        public void RemoveCarRecord(int id)
        {
            try
            {
                var carRecordFromDb = _unitOfWork.CarRecord.Get(u => u.Id == id);
                _unitOfWork.CarRecord.Remove(carRecordFromDb);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Error while deleting the CarRecord with id {id}.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Database error while deleting the CarRecord with id {id}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting the CarRecord with id {id}.", ex);
            }
        }

        public void UpdateCarRecord(CarRecordDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRecord>(objDTO);
                _unitOfWork.CarRecord.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating data", ex);
            }
        }
    }
}
