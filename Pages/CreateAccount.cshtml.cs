using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Capstone1.Data;
using Capstone1.Models;

namespace Capstone1.Pages
{
    public class CreateAccountModel : PageModel
    {
        private readonly AppDBContext _context;

        [BindProperty]
        public User User { get; set; }


        public CreateAccountModel(AppDBContext context)
        {
            _context = context;
        }



        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newUser = new User
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                DateOfBirth = User.DateOfBirth,
                Email = User.Email,
                CompanyName = User.CompanyName
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Profile");
        }
    }
}
