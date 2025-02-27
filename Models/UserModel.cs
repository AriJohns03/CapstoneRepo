using System.ComponentModel.DataAnnotations;

namespace Capstone1.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; } = "User"; // Default role

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Track user creation
    }

}
