using CountersApp.Model;
using Microsoft.AspNetCore.Mvc;
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
        
        [BindProperty]
        public Counter Counter { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Message = $"New Counter: Key = {Counter.Key} Value = {Counter.Value}";
            _countersRepository.AddCounter(Counter);
            return Redirect("counterspage");
        }
    }
}