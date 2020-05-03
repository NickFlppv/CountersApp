using System;
using System.Linq;
using CountersApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CountersApp.Pages
{
    public class CountersPage : PageModel
    {
        private readonly ICountersRepository _countersRepository;

        public CountersPage(ICountersRepository countersRepository)
        {
            _countersRepository = countersRepository;
        }
        public string Message { get; private set; } = "";
        public IQueryable<Counter> CountersList { get; private set; }

        public void OnGet()
        {
            Message += $" Page = Counters";
            CountersList = _countersRepository.GetCounters().OrderBy(c => c.Key);
        }
    }
}