using BMW_GarageWebApi.BLL.Interfaces;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRepair;
using BMW_GarageWebApi.Utility;
using BMW_GarageWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarRepairVM objVM)
        {
            if (ModelState.IsValid)
            {
                var objDTO = new CarRepairDTO
                {
                    Id = objVM.Id,
                    TypeOfCarRepair = objVM.TypeOfCarRepair,
                    PriceMin = objVM.PriceMin,
                    PriceMax = objVM.PriceMax
                };

                _carRepairService.AddCarRepair(objDTO);
                TempData["success"] = "Нова послуга успішно створена";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {        
            if (id == 0)
            {
                return NotFound();
            }

            var carRepairDTO = _carRepairService.GetCarRepair(id);

            if (carRepairDTO == null)
            {
                return NotFound();
            }
            var carRepairVM = new CarRepairVM
            {
                Id = carRepairDTO.Id,
                TypeOfCarRepair = carRepairDTO.TypeOfCarRepair,
                PriceMin = carRepairDTO.PriceMin,
                PriceMax = carRepairDTO.PriceMax
            };
            return View(carRepairVM);
        }

        [HttpPost]
        public IActionResult Edit(CarRepairVM objVM)
        {
            if (ModelState.IsValid)
            {
                var objDTO = new CarRepairDTO
                {
                    Id = objVM.Id,
                    TypeOfCarRepair = objVM.TypeOfCarRepair,
                    PriceMin = objVM.PriceMin,
                    PriceMax = objVM.PriceMax
                };

                _carRepairService.UpdateCarRepair(objDTO);
                TempData["success"] = "Послуга успішно оновлена";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var carRepairDTO = _carRepairService.GetCarRepair(id);

            if (carRepairDTO == null)
            {
                return NotFound();
            }
            var carRepairVM = new CarRepairVM
            {
                Id = carRepairDTO.Id,
                TypeOfCarRepair = carRepairDTO.TypeOfCarRepair,
                PriceMin = carRepairDTO.PriceMin,
                PriceMax = carRepairDTO.PriceMax
            };
            return View(carRepairVM);
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
