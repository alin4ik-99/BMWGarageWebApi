using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRepair;
using BMW_GarageWebApi.Domain.DTOModels.DTOEmployee;
using BMW_GarageWebApi.Utility;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace BMW_GarageWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var employeeListDTO = await _employeeService.GetAllEmployee();

            var employeeListVM = employeeListDTO.Select(obj => new EmployeeVM_Index
            {
                Id = obj.Id,
                FullName = obj.FullName,
                DateOfBirth = obj.DateOfBirth,
                DateOfHiring = obj.DateOfHiring,
                Gender = obj.Gender,
                Email = obj.Email,
                PhoneNumber = obj.PhoneNumber,
                Position = obj.Position
                
            });

            if (!String.IsNullOrEmpty(searchString))
            {
                employeeListVM = employeeListVM.Where(s => s.FullName!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(employeeListVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM objVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var objDTO = new EmployeeDTO
                {
                    Id = objVM.Id,
                    FullName = objVM.FullName,
                    DateOfBirth = objVM.DateOfBirth,
                    DateOfHiring = objVM.DateOfHiring,
                    Gender = objVM.Gender,
                    Email = objVM.Email,
                    PhoneNumber = objVM.PhoneNumber,
                    Position = objVM.Position,
                    ImageDate = objVM.ImageBase64 != null ? Convert.FromBase64String(objVM.ImageBase64) : null,
                    Notes = objVM.Notes
                };

                await _employeeService.UpdateEmployee(objDTO, file);
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employeeDTO = await _employeeService.GetEmployee(id);

            if (employeeDTO == null)
            {
                return NotFound();
            }

            var employeeVM = new EmployeeVM
            {
                Id = employeeDTO.Id,
                FullName = employeeDTO.FullName,
                DateOfBirth = employeeDTO.DateOfBirth,
                DateOfHiring = employeeDTO.DateOfHiring,
                Gender = employeeDTO.Gender,
                Email = employeeDTO.Email,
                PhoneNumber = employeeDTO.PhoneNumber,
                Position = employeeDTO.Position,
                ImageBase64 = employeeDTO.ImageDate != null ? Convert.ToBase64String(employeeDTO.ImageDate) : null,
                Notes = employeeDTO.Notes
            };

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM objVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var objDTO = new EmployeeDTO
                {
                    Id = objVM.Id,
                    FullName = objVM.FullName,
                    DateOfBirth = objVM.DateOfBirth,
                    DateOfHiring = objVM.DateOfHiring,
                    Gender = objVM.Gender,
                    Email = objVM.Email,
                    PhoneNumber = objVM.PhoneNumber,
                    Position = objVM.Position,
                    ImageDate = objVM.ImageBase64 != null ? Convert.FromBase64String(objVM.ImageBase64) : null,
                    Notes = objVM.Notes
                };

                await _employeeService.UpdateEmployee(objDTO, file);
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employeeDTO = await _employeeService.GetEmployee(id);

            if (employeeDTO == null)
            {
                return NotFound();
            }

            var employeeVM = new EmployeeVM
            {
                Id = employeeDTO.Id,
                FullName = employeeDTO.FullName,
                DateOfBirth = employeeDTO.DateOfBirth,
                DateOfHiring = employeeDTO.DateOfHiring,
                Gender = employeeDTO.Gender,
                Email = employeeDTO.Email,
                PhoneNumber = employeeDTO.PhoneNumber,
                Position = employeeDTO.Position,
                ImageBase64 = employeeDTO.ImageDate != null ? Convert.ToBase64String(employeeDTO.ImageDate) : null,
                Notes = employeeDTO.Notes
            };

            return View(employeeVM);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _employeeService.RemoveEmployee(id);
            TempData["success"] = "Employee deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
