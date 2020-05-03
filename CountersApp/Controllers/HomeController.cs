using System;
using System.Linq;
using System.Text.Json;
using CountersApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace CountersApp.Controllers
{
    public class HomeController : Controller
    {
        private const int _itemsPerPage = 3;
        private readonly ICountersRepository _countersRepository;

        public HomeController(ICountersRepository countersRepository)
        {
            _countersRepository = countersRepository;
        }

        public IActionResult Index() => View();

        public IActionResult CountMoreThanOne() => View(_countersRepository.GetCounts());

        [HttpGet("counts")]
        public IActionResult GetCountMoreThanOne(int page = 1)
        {
            if (page < 1)
            {
                return BadRequest();
            }
            var response = _countersRepository.GetCounts()
                .Skip(_itemsPerPage * (page - 1))
                .Take(_itemsPerPage)
                .Select(c => new {Key = c.Item1, Count = c.Item2, CountMoreThanOne = c.Item3})
                .ToList();
            
            return Ok(JsonSerializer.Serialize(response));
        }
    }
}