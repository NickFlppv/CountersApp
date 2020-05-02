using System;
using CountersApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace CountersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountersRepository _countersRepository;

        public HomeController(ICountersRepository countersRepository)
        {
            _countersRepository = countersRepository;
        }

        public IActionResult Index() => View();

        public IActionResult CountMoreThanOne()
        {
            return View(_countersRepository.GetCounts());
        }
    }
}