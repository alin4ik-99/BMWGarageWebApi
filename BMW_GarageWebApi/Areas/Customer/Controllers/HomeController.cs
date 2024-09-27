using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        public async Task<IActionResult> Create()
        {
            var employeeList = await _employeeService.GetAllEmployee();

            CarRecordVM carRecordVM = new()
            {
                EmployeeList = employeeList.Select(u => new SelectListItem
                {
                   Text = u.FullName,
                   Value = u.Id.ToString()
                }),
                DateOfVisit = DateOnly.FromDateTime(DateTime.Now)
            };
            return View(carRecordVM);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CarRecordVM carRecordVM)
        {            
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                carRecordVM.ApplicationUserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

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

                await _carRecordService.AddCarRecord(carRecordDTO);
                TempData["success"] = "Welcome! The record was created successfully. We will contact you as soon as possible. Thank you for choosing us!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "The data was entered incorrectly";
                return RedirectToAction("Index");
            }

        }
    }
}
