using BMW_GarageWebApi.Domain.DTOModels.DTOEmployee;
using Microsoft.AspNetCore.Http;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployee();
        Task<EmployeeDTO> GetEmployee(int id);
        Task RemoveEmployee(int id);
        Task AddEmployee(EmployeeDTO objDTO, IFormFile? file);
        Task UpdateEmployee(EmployeeDTO objDTO, IFormFile? file);
    }
}
