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
        public void AddCarRepair(CarRepairDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRepair>(objDTO);
                _unitOfWork.CarRepair.Add(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding data", ex);
            }

        }

        public IEnumerable<CarRepairDTO> GetAllCarRepair()
        {
            try
            {
                var carRepairList = _unitOfWork.CarRepair.GetAll();
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

        public CarRepairDTO GetCarRepair(int id)
        {
            try
            {
                var carRepair = _unitOfWork.CarRepair.Get(u => u.Id == id);
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

        public void RemoveCarRepair(int id)
        {
            try
            {
                var carRepairFromDb = _unitOfWork.CarRepair.Get(u => u.Id == id);
                _unitOfWork.CarRepair.Remove(carRepairFromDb);
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

        public void UpdateCarRepair(CarRepairDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CarRepair>(objDTO);
                _unitOfWork.CarRepair.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating data", ex);
            }

        }
    }
}
