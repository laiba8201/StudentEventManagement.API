namespace StudentEventManagement.Domain.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Foreign Key
        public int EventId { get; set; }
        public Event Event { get; set; }

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    }
}
