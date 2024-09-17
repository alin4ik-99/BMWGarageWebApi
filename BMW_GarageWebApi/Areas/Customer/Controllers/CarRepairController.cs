using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Utility;
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
            var objCarRepairList = _carRepairService.GetAllCarRepair();

            if (!String.IsNullOrEmpty(searchString))
            {
                objCarRepairList = objCarRepairList.Where(s => s.TypeOfCarRepair!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(objCarRepairList);
        }

    }
}