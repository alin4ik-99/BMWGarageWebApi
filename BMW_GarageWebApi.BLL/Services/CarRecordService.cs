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
        public async Task AddCarRecord(CarRecordDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRecord>(objDTO);
                await _unitOfWork.CarRecord.AddAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding data", ex);
            }
        }

        public async Task<IEnumerable<CarRecordDTO>> GetAllCarRecord()
        {
            try
            {
                var carRecordList = await _unitOfWork.CarRecord.GetAllAsync( includeProperties: "Employee");
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

        public async Task<IEnumerable<CarRecordDTO>> GetAllCarRecordUser(string userId)
        {
            try
            {
                var carRecordList = await _unitOfWork.CarRecord.GetAllAsync(u => u.ApplicationUserId == userId, includeProperties: "Employee");
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

        public async Task<CarRecordDTO> GetCarRecord(int id)
        {
            try
            {
                var carRecord = await _unitOfWork.CarRecord.GetAsync(u => u.Id == id);
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

        public async Task RemoveCarRecord(int id)
        {
            try
            {
                var carRecordFromDb = await _unitOfWork.CarRecord.GetAsync(u => u.Id == id);
                await _unitOfWork.CarRecord.RemoveAsync(carRecordFromDb);
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

        public async Task UpdateCarRecord(CarRecordDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRecord>(objDTO);
                await _unitOfWork.CarRecord.UpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating data", ex);
            }
        }
    }
}
