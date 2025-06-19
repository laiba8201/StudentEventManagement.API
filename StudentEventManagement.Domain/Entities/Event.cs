using System;
using System.Collections.Generic;

namespace StudentEventManagement.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }                  // Primary Key
        public string Title { get; set; }            // Event title
        public DateTime Date { get; set; }           // Event date
        public string Location { get; set; }         // Event location

        // Navigation Properties
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    }
}
