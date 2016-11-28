using CapacitorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapacitorWebApplication.Controllers
{
    public class MaterialController : Controller
    {
        private IMaterialRepository repository;
        public MaterialController(IMaterialRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Materials);
    }
}
