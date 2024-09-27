using AutoMapper;
using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRepair;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BMW_GarageWebApi.BLL.Services
{
    public class CarRepairService : ICarRepairService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarRepairService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        public async Task AddCarRepair(CarRepairDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRepair>(objDTO);
                await _unitOfWork.CarRepair.AddAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding data", ex);
            }

        }

        public async Task<IEnumerable<CarRepairDTO>> GetAllCarRepair()
        {
            try
            {
                var carRepairList = await _unitOfWork.CarRepair.GetAllAsync();
                var carRepairListDTO = _mapper.Map<IEnumerable<CarRepairDTO>>(carRepairList);
                return carRepairListDTO;
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

        public async Task<CarRepairDTO> GetCarRepair(int id)
        {
            try
            {
                var carRepair = await _unitOfWork.CarRepair.GetAsync(u => u.Id == id);
                var carRepairDTO = _mapper.Map<CarRepairDTO>(carRepair);
                return carRepairDTO;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"An error occurred while retrieving the CarRepair with id {id}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the CarRepair with id {id}.", ex);
            }
        }

        public async Task RemoveCarRepair(int id)
        {
            try
            {
                var carRepairFromDb = await _unitOfWork.CarRepair.GetAsync(u => u.Id == id);
                await _unitOfWork.CarRepair.RemoveAsync(carRepairFromDb);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Error while deleting the CarRepair with id {id}.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Database error while deleting the CarRepair with id {id}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting the CarRepair with id {id}.", ex);
            }

        }

        public async Task UpdateCarRepair(CarRepairDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRepair>(objDTO);
                await _unitOfWork.CarRepair.UpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating data", ex);
            }

        }
    }
}
