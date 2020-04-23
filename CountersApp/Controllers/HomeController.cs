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

        [HttpGet("{key}")]
        public IActionResult CountsOfCounters(int key) => View(_countersRepository.GetCounts(key).ToTuple());
    }
}