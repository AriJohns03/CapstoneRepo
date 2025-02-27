using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Capstone1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public UserDto Input { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var token = await _authService.AuthenticateUser(Input.Username, Input.Password);
            if (token == null)
            {
                Message = "Invalid username or password.";
                return Page();
            }

            // Store JWT in session or cookies
            HttpContext.Session.SetString("AuthToken", token);
            return RedirectToPage("/Dashboard");
        }
    }

}
