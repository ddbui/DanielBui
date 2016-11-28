using Microsoft.AspNetCore.Mvc;

namespace CapacitorWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Index");
    }
}
