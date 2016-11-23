using CapacitorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapacitorWebApplication.Controllers
{
    public class ResinController : Controller
    {
        private IResinRepository repository;
        public ResinController(IResinRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Resins);
    }
}
