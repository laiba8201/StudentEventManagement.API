namespace StudentEventManagement.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int Rating { get; set; }  // e.g., 1 to 5 stars
        public string Comment { get; set; }

        // Foreign Key
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
