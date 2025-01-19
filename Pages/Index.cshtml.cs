using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CadastroPacientesWEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            
            if (Username == "medico1" && Password == "123456")
            {
                
                return RedirectToPage("/Cadastro");
            }
            else
            {
                ModelState.AddModelError("", "Login ou senha inv�lidos.");
                return Page();
            }
        }
    }
}