using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        void RemoveEmployee(int id);
        void AddEmployee(Employee entity, IFormFile? file);
        void UpdateEmployee(Employee entity, IFormFile? file);
    }
}
