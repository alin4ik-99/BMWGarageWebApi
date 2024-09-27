using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BMW_GarageWebApi.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class UserCarRecordController : Controller
    {
        private readonly ICarRecordService _carRecordService;
        private readonly IEmployeeService _employeeService;
        public UserCarRecordController(ICarRecordService carRecordService, IEmployeeService employeeService)
        {
            _carRecordService = carRecordService;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var carRecordListDTO = await _carRecordService.GetAllCarRecordUser(userId);

            var carRecordListVM = carRecordListDTO.Select(obj => new CarRecordVM
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Email = obj.Email,
                PhoneNumber = obj.PhoneNumber,
                Description = obj.Description,
                DateOfVisit = obj.DateOfVisit,
                StatusCarRecord = obj.StatusCarRecord,
                EmployeeId = obj.EmployeeId,
                Employee = obj.Employee,
                ApplicationUserId = obj.ApplicationUserId
            });

            if (!String.IsNullOrEmpty(searchString))
            {
                carRecordListVM = carRecordListVM.Where(s => s.FullName!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(carRecordListVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employeeList = await _employeeService.GetAllEmployee();

            CarRecordVM carRecordVM = new()
            {
                EmployeeList = employeeList.Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                }),
            };

            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var objCarRecord = await _carRecordService.GetCarRecord(id);

                if (objCarRecord != null)
                {
                    carRecordVM.Id = objCarRecord.Id;
                    carRecordVM.FullName = objCarRecord.FullName;
                    carRecordVM.Email = objCarRecord.Email;
                    carRecordVM.PhoneNumber = objCarRecord.PhoneNumber;
                    carRecordVM.Description = objCarRecord.Description;
                    carRecordVM.DateOfVisit = objCarRecord.DateOfVisit;
                    carRecordVM.StatusCarRecord = objCarRecord.StatusCarRecord;
                    carRecordVM.EmployeeId = objCarRecord.EmployeeId;
                    carRecordVM.ApplicationUserId = objCarRecord.ApplicationUserId;
                }
                return View(carRecordVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarRecordVM carRecordVM)
        {
            if (ModelState.IsValid)
            {
                CarRecordDTO carRecordDTO = new()
                {
                    Id = carRecordVM.Id,
                    FullName = carRecordVM.FullName,
                    Email = carRecordVM.Email,
                    PhoneNumber = carRecordVM.PhoneNumber,
                    Description = carRecordVM.Description,
                    DateOfVisit = carRecordVM.DateOfVisit,
                    StatusCarRecord = carRecordVM.StatusCarRecord,
                    EmployeeId = carRecordVM.EmployeeId,
                    ApplicationUserId = carRecordVM.ApplicationUserId
                };

                await _carRecordService.UpdateCarRecord(carRecordDTO);
                TempData["success"] = "The record has been updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                var employeeList = await _employeeService.GetAllEmployee();

                carRecordVM.EmployeeList = employeeList.Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                });

                return View(carRecordVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employeeList = await _employeeService.GetAllEmployee();

            CarRecordVM carRecordVM = new()
            {
                EmployeeList = employeeList.Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                }),
            };

            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var objCarRecord = await _carRecordService.GetCarRecord(id);

                if (objCarRecord != null)
                {
                    carRecordVM.Id = objCarRecord.Id;
                    carRecordVM.FullName = objCarRecord.FullName;
                    carRecordVM.Email = objCarRecord.Email;
                    carRecordVM.PhoneNumber = objCarRecord.PhoneNumber;
                    carRecordVM.Description = objCarRecord.Description;
                    carRecordVM.DateOfVisit = objCarRecord.DateOfVisit;
                    carRecordVM.StatusCarRecord = objCarRecord.StatusCarRecord;
                    carRecordVM.EmployeeId = objCarRecord.EmployeeId;
                    carRecordVM.ApplicationUserId = objCarRecord.ApplicationUserId;
                }
                return View(carRecordVM);
            }
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _carRecordService.RemoveCarRecord(id);
            TempData["success"] = "The record has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
