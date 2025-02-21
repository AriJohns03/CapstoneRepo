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
        public string Password { get; set; }

        public UserModel()
        {
            
        }

        public UserModel(string FirstName, string LastName, DateTime DateOfBirth, string Email, string CompanyName, string Username, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Email = Email;
            this.CompanyName = CompanyName;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
