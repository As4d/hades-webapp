using HadesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess;

namespace HadesProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(new UserModel
            {
                NoOfUsers = _repository.GetTotalNumberOfUsers(),
                NoOfScans =  _repository.GetTotalNumberOfScans()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
