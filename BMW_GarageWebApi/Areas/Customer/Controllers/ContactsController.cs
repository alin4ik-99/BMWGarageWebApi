using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.Utility;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

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
        public async Task<IActionResult> Index()
        {
            var employeeListDTO = await _employeeService.GetAllEmployee();

            var employeeListVM = employeeListDTO.Select(obj => new EmployeeVM_Contacts
            {
                FullName = obj.FullName,
                Email = obj.Email,
                PhoneNumber = obj.PhoneNumber,
                ImageUrl = obj.ImageUrl,
                Notes = obj.Notes
            });           

            return View(employeeListVM);
        }
    }
}
