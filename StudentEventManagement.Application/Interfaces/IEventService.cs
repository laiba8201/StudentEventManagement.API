using StudentEventManagement.Application.DTOs;

namespace StudentEventManagement.Application.Interfaces
{
    public interface IEventService
    {
        Task<List<EventDto>> GetAllEventsAsync();
        Task<EventDto> GetEventByIdAsync(int id);
        Task<EventDto> CreateEventAsync(EventDto dto);

        // 🔧 Fix this line:
        Task<bool> UpdateEventAsync(int id, EventDto dto);

        Task<bool> DeleteEventAsync(int id);
        Task<List<EventDto>> SearchEventsAsync(string query);
        Task<List<EventDto>> FilterEventsAsync(string sort);

        // Optional: Only include this if you're implementing it in the service
        Task<IEnumerable<EventDto>> FilterEventsByDateAsync();
    }
}
