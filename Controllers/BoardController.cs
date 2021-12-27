using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class BoardController : Controller
    {
        public ActionResult List(int? Id) 
        {
            if (Id == null)
                return Content("ErrorMessage #1");

            return View();
        }
    }
}
