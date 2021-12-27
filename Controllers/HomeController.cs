using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "My First Application!";
        }
    }
}
