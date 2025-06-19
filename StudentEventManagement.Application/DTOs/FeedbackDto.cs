namespace StudentEventManagement.Application.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }              // Optional
        public int Rating { get; set; }          // Required (e.g., 1–5)
        public string Comment { get; set; }      // Optional
        public int EventId { get; set; }         // Link to event
    }
}
