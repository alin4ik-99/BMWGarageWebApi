using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Utility;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMW_GarageWebApi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CarRepairController : Controller
    {
        private readonly ICarRepairService _carRepairService;
        public CarRepairController(ICarRepairService carRepairService)
        {
            _carRepairService = carRepairService;
        }

        public IActionResult Index(string searchString)
        {
            var carRepairListDTO = _carRepairService.GetAllCarRepair();

            var carRepairListVM = carRepairListDTO.Select(obj => new CarRepairVM
            {
                Id = obj.Id,
                TypeOfCarRepair = obj.TypeOfCarRepair,
                PriceMin = obj.PriceMin,
                PriceMax = obj.PriceMax
            });

            if (!String.IsNullOrEmpty(searchString))
            {
                carRepairListVM = carRepairListVM.Where(s => s.TypeOfCarRepair!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(carRepairListVM);
        }

    }
}