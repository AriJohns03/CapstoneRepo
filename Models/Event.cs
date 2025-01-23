namespace Capstone1.Models
{
    public class Event
    {
        private static int nextID = 0;
        public int Id { get; set; } = nextID++;

        public string Name { get; set; }

        public int Time { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public bool AgeRestriction { get; set; }

        public string Description { get; set; }

    }

}
