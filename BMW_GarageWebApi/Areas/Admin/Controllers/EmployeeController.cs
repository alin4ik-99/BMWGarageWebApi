using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Index(string searchString)
        {
            var objEmployeeList = _employeeService.GetAllEmployee();

            if (!String.IsNullOrEmpty(searchString))
            {
                objEmployeeList = objEmployeeList.Where(s => s.FullName!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(objEmployeeList);
        }


        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {

                _employeeService.UpdateEmployee(obj, file);
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employeeFromDb = _employeeService.GetEmployee(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Employee obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(obj, file);
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employeeFromDb = _employeeService.GetEmployee(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {

            _employeeService.RemoveEmployee(id);
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
