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

    }
}