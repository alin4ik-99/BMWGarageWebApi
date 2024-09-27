﻿using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using BMW_GarageWebApi.Domain.DTOModels.DTOEmployee;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BMW_GarageWebApi.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        public async Task AddEmployee(EmployeeDTO objDTO, IFormFile? file)
        {
            try
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

                    objDTO.ImageUrl = @"\images\employee\" + fileName;
                }
                var obj = _mapper.Map<Employee>(objDTO);
                await _unitOfWork.Employee.AddAsync(obj);
            }

            catch (DirectoryNotFoundException ex) 
            { 
                throw new Exception("Directory for save picture not found", ex); 
            }
            catch (FileNotFoundException ex) 
            { 
                throw new Exception("File not found", ex); 
            }
            catch (IOException ex) 
            { 
                throw new Exception("Input/output error when working with files", ex); 
            }
            catch (Exception ex) 
            { 
                throw new Exception("An error occurred while adding data", ex); 
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployee()
        {
            try
            {
                var employeeList = await _unitOfWork.Employee.GetAllAsync();
                var employeeListDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeList);
                return employeeListDTO;
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

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            try
            { 
                var employee = await _unitOfWork.Employee.GetAsync(u => u.Id == id);             
                var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
                return employeeDTO;
            }
            catch (InvalidOperationException ex) 
            { 
                throw new Exception($"An error occurred while retrieving the EMPLOYEE with id {id}.", ex); 
            }
            catch (Exception ex) 
            { 
                throw new Exception($"An error occurred while retrieving the EMPLOYEE with id {id}.", ex); 
            }
        }

        public async Task RemoveEmployee(int id)
        {
            try
            {
                var employeeFromDb = await _unitOfWork.Employee.GetAsync(u => u.Id == id);

                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, employeeFromDb.ImageUrl.TrimStart('\\'));

                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }

                await _unitOfWork.Employee.RemoveAsync(employeeFromDb);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Error while deleting the employee with id {id}.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Database error while deleting the employee with id {id}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting the employee with id {id}.", ex);
            }

        }

        public async Task UpdateEmployee(EmployeeDTO objDTO, IFormFile? file)
        {
            try
            {
                var obj = _mapper.Map<Employee>(objDTO);

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string employeePath = Path.Combine(wwwRootPath, @"images\employee");
                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (File.Exists(oldImagePath))
                        {
                            File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\employee\" + fileName;
                }
                await _unitOfWork.Employee.UpdateAsync(obj);
            }
            catch (DirectoryNotFoundException ex) 
            { 
                throw new Exception("Directory for save picture not found", ex);
            }
            catch (FileNotFoundException ex) 
            { 
                throw new Exception("File not found", ex); 
            }
            catch (IOException ex)
            { 
                throw new Exception("Input/output error when working with files", ex); 
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating data", ex); 
            }
        }
    }
}
