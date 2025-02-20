using System.ComponentModel.DataAnnotations;

namespace Capstone1.Models
{
    public class CreateAcount
    {
        private static int nextID = 0;
        [Key]
        public int Id { get; set; } = nextID++;
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

        public string CompanyName { get; set; }
    }
}
