using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using BMW_GarageWebApi.BLL.Interfaces;

namespace BMW_GarageWebApi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRecordService _carRecordService;
        private readonly IEmployeeService _employeeService;
        public HomeController(ILogger<HomeController> logger,  ICarRecordService carRecordService, IEmployeeService employeeService)
        {
            _logger = logger;
            _carRecordService = carRecordService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                TempData["success"] = "Вітаємо! Запис успішно створено. Ми зв'яжемося з Вами найближчим часом. Дякуємо, що обрали нас!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Дані введено неправідлово";
                return RedirectToAction("Index");
            }

        }
    }
}
