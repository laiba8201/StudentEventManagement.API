using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;
using StudentEventManagement.Domain.Entities;
using StudentEventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace StudentEventManagement.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            return await _context.Events
                .Where(e => e.Date >= DateTime.Today)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Location = e.Location,
                    Date = e.Date
                }).ToListAsync();
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return null;

            return new EventDto
            {
                Id = e.Id,
                Title = e.Title,
                Location = e.Location,
                Date = e.Date
            };
        }

        public async Task<EventDto> CreateEventAsync(EventDto dto)
        {
            var newEvent = new Event
            {
                Title = dto.Title,
                Location = dto.Location,
                Date = dto.Date
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            dto.Id = newEvent.Id;
            return dto;
        }

        public async Task<bool> UpdateEventAsync(int id, EventDto dto)
        {
            var existing = await _context.Events.FindAsync(id);
            if (existing == null) return false;

            existing.Title = dto.Title;
            existing.Location = dto.Location;
            existing.Date = dto.Date;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteEventAsync(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return false;

            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EventDto>> SearchEventsAsync(string query)
        {
            return await _context.Events
                .Where(e => e.Title.Contains(query) || e.Location.Contains(query))
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Location = e.Location
                })
                .ToListAsync();
        }


        public async Task<List<EventDto>> FilterEventsAsync(string sort)
        {
            IQueryable<Event> events = _context.Events;

            if (sort == "date")
                events = events.OrderBy(e => e.Date);
            else if (sort == "location")
                events = events.OrderBy(e => e.Location);

            return await events.Select(e => new EventDto
            {
                Id = e.Id,
                Title = e.Title,
                Date = e.Date,
                Location = e.Location
            }).ToListAsync();
        }

        public async Task<IEnumerable<EventDto>> FilterEventsByDateAsync()
        {
            var today = DateTime.Today;
            return await _context.Events
                .Where(e => e.Date >= today)
                .OrderBy(e => e.Date)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Location = e.Location
                })
                .ToListAsync();
        }



    }
}






