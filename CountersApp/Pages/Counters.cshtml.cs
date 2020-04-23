using System;
using System.Linq;
using CountersApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CountersApp.Pages
{
    public class Counters : PageModel
    {
        private readonly ICountersRepository _countersRepository;

        public Counters(ICountersRepository countersRepository)
        {
            _countersRepository = countersRepository;
        }
        public string Message { get; private set; } = "PageModel in C#";
        public IQueryable<Counter> CountersList { get; private set; }

        public void OnGet()
        {
            Message += $" Page = Counters";
            CountersList = _countersRepository.GetCounters();
        }
    }
}