namespace StudentEventManagement.Domain.Entities
{
    public class Registration
    {
        public int Id { get; set; }

        // Foreign keys
        public int EventId { get; set; }
        public int ParticipantId { get; set; }

        // Navigation properties
        public Event Event { get; set; } = null!;
        public Participant Participant { get; set; } = null!;

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
