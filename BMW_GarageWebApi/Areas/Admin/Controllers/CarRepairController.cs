using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BMW_GarageWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarRepairController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarRepairController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchString)
        {
            var objCarRepairList = _unitOfWork.CarRepair.GetAll();

            if (objCarRepairList == null)
            {
                return Problem("Entity set 'CarRepair'  is null.");
            }


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
                _unitOfWork.CarRepair.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Нова послуга успішно створена";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CarRepairFromDb = _unitOfWork.CarRepair.Get(u => u.Id == id);

            if (CarRepairFromDb == null)
            {
                return NotFound();
            }

            return View(CarRepairFromDb);
        }


        [HttpPost]
        public IActionResult Edit(CarRepair obj)
        {

            if (ModelState.IsValid)
            {
          
                _unitOfWork.CarRepair.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Послуга успішно оновлена";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CarRepairFromDb = _unitOfWork.CarRepair.Get(u => u.Id == id);

            if (CarRepairFromDb == null)
            {
                return NotFound();
            }

            return View(CarRepairFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CarRepair.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CarRepair.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Послуга успішно видалена";
            return RedirectToAction("Index");

        }
    }
}
