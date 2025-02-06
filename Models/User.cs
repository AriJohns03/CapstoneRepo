namespace Capstone1.Models
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public string CompanyName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
