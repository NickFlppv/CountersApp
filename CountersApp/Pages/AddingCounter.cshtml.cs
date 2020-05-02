using CountersApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CountersApp.Pages
{
    public class AddingCounter : PageModel
    {
        private readonly ICountersRepository _countersRepository;

        public AddingCounter(ICountersRepository countersRepository)
        {
            _countersRepository = countersRepository;
        }
        public string Message { get; private set; } = "";

        public void OnGet()
        {
            Message += $"Page = AddingCounter";
        }

        public void OnPost(Counter counter)
        {
            _countersRepository.AddCounter(counter);
        }
    }
}