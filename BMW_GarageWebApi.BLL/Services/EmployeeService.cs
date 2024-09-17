using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMW_GarageWebApi.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void AddEmployee(Employee entity, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string employeePath = Path.Combine(wwwRootPath, @"images\employee");

                using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                entity.ImageUrl = @"\images\employee\" + fileName;

            }

            _unitOfWork.Employee.Add(entity);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            var objEmployeeList = _unitOfWork.Employee.GetAll();
            return objEmployeeList;
        }

        public Employee GetEmployee(int id)
        {
            var employeeFromDb = _unitOfWork.Employee.Get(u => u.Id == id);
            return employeeFromDb;
        }

        public void RemoveEmployee(int id)
        {
            var employeeFromDb = _unitOfWork.Employee.Get(u => u.Id == id);

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, employeeFromDb.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Employee.Remove(employeeFromDb);
        }

        public void UpdateEmployee(Employee entity, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string employeePath = Path.Combine(wwwRootPath, @"images\employee");
                if (!string.IsNullOrEmpty(entity.ImageUrl))
                {
                    //delete the old image
                    var oldImagePath = Path.Combine(wwwRootPath, entity.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                entity.ImageUrl = @"\images\employee\" + fileName;
            }

            _unitOfWork.Employee.Update(entity);
        }
    }
}
