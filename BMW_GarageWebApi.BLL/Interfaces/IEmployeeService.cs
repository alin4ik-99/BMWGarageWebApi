using BMW_GarageWebApi.Domain.DTOModels.DTOEmployee;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployee();
        EmployeeDTO GetEmployee(int id);
        void RemoveEmployee(int id);
        void AddEmployee(EmployeeDTO objDTO, IFormFile? file);
        void UpdateEmployee(EmployeeDTO objDTO, IFormFile? file);
    }
}
