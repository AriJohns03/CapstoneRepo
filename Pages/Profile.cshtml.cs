//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Capstone1.Data;
//using Capstone1.Models;
//using System.Linq;

//public class ProfileModel : PageModel
//{
//    private readonly AppDBContext context;

//    public ProfileModel(AppDBContext _context)
//    {
//        _context = context;
//    }

//    public UserDto? UserProfile { get; private set; } // Ensure it's a property

//    public IActionResult OnGet(string username)
//    {
//        if (string.IsNullOrEmpty(username))
//        {
//            return NotFound("Username is required.");
//        }

//        var user = context.Users.FirstOrDefault(u => u.Username == username);

//        if (user == null)
//        {
//            return NotFound("User not found.");
//        }

//        UserProfile = new UserDto
//        {
//            Username = user.Username,
//            FirstName = user.FirstName,
//            LastName = user.LastName,
//            DateOfBirth = user.DateOfBirth,
//            Email = user.Email,
//            CompanyName = user.CompanyName
//        };

//        return Page();
//    }
//}
