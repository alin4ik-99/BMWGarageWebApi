using Microsoft.AspNetCore.Mvc;

namespace BMW_GarageWebApi.Areas.Admin.Controllers
{
    public class CarRecordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
