using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using BMW_GarageWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BMW_GarageWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CarRepair obj)
        {

            if (ModelState.IsValid)
            {
                _carRepairService.AddCarRepair(obj);
                TempData["success"] = "Нова послуга успішно створена";
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

            var carRepairFromDb = _carRepairService.GetCarRepair(id);

            if (carRepairFromDb == null)
            {
                return NotFound();
            }

            return View(carRepairFromDb);
        }


        [HttpPost]
        public IActionResult Edit(CarRepair obj)
        {

            if (ModelState.IsValid)
            {

                _carRepairService.UpdateCarRepair(obj);
                TempData["success"] = "Послуга успішно оновлена";
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

            var carRepairFromDb = _carRepairService.GetCarRepair(id);

            if (carRepairFromDb == null)
            {
                return NotFound();
            }

            return View(carRepairFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            _carRepairService.RemoveCarRepair(id);
            TempData["success"] = "Послуга успішно видалена";
            return RedirectToAction("Index");
        }
    }
}
