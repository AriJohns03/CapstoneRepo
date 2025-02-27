using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Capstone1.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) {}

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class User
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
