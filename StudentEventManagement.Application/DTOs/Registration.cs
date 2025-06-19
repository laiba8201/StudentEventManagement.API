namespace StudentEventManagement.Application.DTOs
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
