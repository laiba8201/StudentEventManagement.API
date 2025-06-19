namespace StudentEventManagement.Application.DTOs
{
    public class ParticipantDto
    {
        public int Id { get; set; }              // Optional for update/fetch
        public string Name { get; set; }         // Required
        public string Email { get; set; }        // Required
        public int EventId { get; set; }         // Link to event
    }
}
