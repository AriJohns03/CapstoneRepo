using System.ComponentModel.DataAnnotations;

namespace Capstone1.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int AgeRestriction { get; set; }
        [Required]
        public string Description { get; set; }

        public Event()
        {
            
        }

        public Event(string Name, DateTime Time, DateTime Date, string Location, int AgeRestriction, string Description)
        {
            this.Name = Name;
            this.Time = Time;
            this.Date = Date;
            this.Location = Location;
            this.AgeRestriction = AgeRestriction;
            this.Description = Description;
        }

    }

}
