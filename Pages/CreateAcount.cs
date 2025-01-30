namespace Capstone1.Pages
{
    public class CreateAcount
    {
        private static int nextID = 0;
        public int Id { get; set; } = nextID++;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }
    }
}
