using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMW_GarageWebApi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ContactsController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public ContactsController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var objEmployeeList = _employeeService.GetAllEmployee();
            return View(objEmployeeList);
        }
    }
}
