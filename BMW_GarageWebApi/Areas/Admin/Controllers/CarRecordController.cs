using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.ViewModels;
using BMW_GarageWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BMW_GarageWebApi.BLL.Interfaces;

namespace BMW_GarageWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CarRecordController : Controller
    {
        private readonly ICarRecordService _carRecordService;
        private readonly IEmployeeService _employeeService;
        public CarRecordController(ICarRecordService carRecordService, IEmployeeService employeeService)
        {
            _carRecordService = carRecordService;
            _employeeService = employeeService;
        }

        public IActionResult Index(string searchString)
        {
            var objCarRecordList = _carRecordService.GetAllCarRecord();

            if (!String.IsNullOrEmpty(searchString))
            {
                objCarRecordList = objCarRecordList.Where(s => s.FullName!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(objCarRecordList);
        }

        public IActionResult Create()
        {
            CarRecordVM carRecordVM = new()
            {
                EmployeeList = _employeeService.GetAllEmployee()
                .Select(u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }),
                 DateOfVisit = DateOnly.FromDateTime(DateTime.Now)                                  
            };          
                return View(carRecordVM);      
        }


        [HttpPost]
        public IActionResult Create(CarRecordVM carRecordVM)
        {
            if (ModelState.IsValid)
            {
                CarRecord objCarRecord = new()
                {
                    Id = carRecordVM.Id,
                    FullName = carRecordVM.FullName,
                    Email = carRecordVM.Email,
                    PhoneNumber = carRecordVM.PhoneNumber,
                    Description = carRecordVM.Description,
                    DateOfVisit = carRecordVM.DateOfVisit,
                    StatusCarRecord = carRecordVM.StatusCarRecord,
                    EmployeeId = carRecordVM.EmployeeId
                };

                _carRecordService.AddCarRecord(objCarRecord);
                TempData["success"] = "Запис успішно створено";
                return RedirectToAction("Index");
            }
            else
            {
                carRecordVM.EmployeeList = _employeeService.GetAllEmployee()
                           .Select(u => new SelectListItem
                           {
                               Text = u.FullName,
                               Value = u.Id.ToString()
                           });

                return View(carRecordVM);
            }           
        }

        public IActionResult Edit(int id)
        {
            CarRecordVM carRecordVM = new()
            {
                EmployeeList = _employeeService.GetAllEmployee()
                .Select(u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }),     
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
              var objCarRecord = _carRecordService.GetCarRecord(id);

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
                }
                return View(carRecordVM);
            }
        }


        [HttpPost]
        public IActionResult Edit(CarRecordVM carRecordVM)
        {
            if (ModelState.IsValid)
            {
                CarRecord objCarRecord = new()
                {
                    Id = carRecordVM.Id,
                    FullName = carRecordVM.FullName,
                    Email = carRecordVM.Email,
                    PhoneNumber = carRecordVM.PhoneNumber,
                    Description = carRecordVM.Description,
                    DateOfVisit = carRecordVM.DateOfVisit,
                    StatusCarRecord = carRecordVM.StatusCarRecord,
                    EmployeeId = carRecordVM.EmployeeId
                };

                _carRecordService.UpdateCarRecord(objCarRecord);
                TempData["success"] = "Запис успішно оновлено";
                return RedirectToAction("Index");
            }
            else
            {
                carRecordVM.EmployeeList = _employeeService.GetAllEmployee()
                           .Select(u => new SelectListItem
                           {
                               Text = u.FullName,
                               Value = u.Id.ToString()
                           });

                return View(carRecordVM);
            }
        }

        public IActionResult Delete(int id)
        {
            CarRecordVM carRecordVM = new()
            {
                EmployeeList = _employeeService.GetAllEmployee()
                .Select(u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }),
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var objCarRecord = _carRecordService.GetCarRecord(id);

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
                }
                return View(carRecordVM);
            }
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            _carRecordService.RemoveCarRecord(id);
            TempData["success"] = "Запис успішно видалено";
            return RedirectToAction("Index");
        }
    }
}
