using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.Domain.ViewModels;
using BMW_GarageWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BMW_GarageWebApi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
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
