using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.Domain.ViewModels;
using BMW_GarageWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMW_GarageWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CarRecordController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarRecordController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchString)
        {
            var objCarRecordList = _unitOfWork.CarRecord.GetAll(includeProperties:"Employee");

            if (objCarRecordList == null)
            {
                return Problem("Entity set 'objCarRecordList'  is null.");
            }


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
                EmployeeList = _unitOfWork.Employee
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }),
                CarRecord = new CarRecord() 
                { 
                    DateOfVisit = DateOnly.FromDateTime(DateTime.Now)                  
                }
            };          
                return View(carRecordVM);
           
        }


        [HttpPost]
        public IActionResult Create(CarRecordVM carRecordVM)
        {


            if (ModelState.IsValid)
            {
   
                _unitOfWork.CarRecord.Add(carRecordVM.CarRecord);
                _unitOfWork.Save();
                TempData["success"] = "Запис успішно створено";
                return RedirectToAction("Index");
            }
            else
            {
                carRecordVM.EmployeeList = _unitOfWork.Employee
                           .GetAll().Select(u => new SelectListItem
                           {
                               Text = u.FullName,
                               Value = u.Id.ToString()
                           });

                return View(carRecordVM);
            }

           
        }


        public IActionResult Edit(int? id)
        {
            CarRecordVM carRecordVM = new()
            {
                EmployeeList = _unitOfWork.Employee
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }),
                CarRecord = new CarRecord()
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                carRecordVM.CarRecord = _unitOfWork.CarRecord.Get(u => u.Id == id);
                return View(carRecordVM);
            }

        }


        [HttpPost]
        public IActionResult Edit(CarRecordVM carRecordVM)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CarRecord.Update(carRecordVM.CarRecord);


                _unitOfWork.Save();
                TempData["success"] = "Запис успішно оновлено";
                return RedirectToAction("Index");
            }
            else
            {
                carRecordVM.EmployeeList = _unitOfWork.Employee
                           .GetAll().Select(u => new SelectListItem
                           {
                               Text = u.FullName,
                               Value = u.Id.ToString()
                           });

                return View(carRecordVM);
            }

        }

        public IActionResult Delete(int? id)
        {
            CarRecordVM carRecordVM = new()
            {
                EmployeeList = _unitOfWork.Employee
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }),
                CarRecord = new CarRecord()
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                carRecordVM.CarRecord = _unitOfWork.CarRecord.Get(u => u.Id == id);
                return View(carRecordVM);
            }
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CarRecord.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CarRecord.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Запис успішно видалено";
            return RedirectToAction("Index");

        }
    }
}
