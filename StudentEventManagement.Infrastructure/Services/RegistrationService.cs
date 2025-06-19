using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;
using StudentEventManagement.Domain.Entities;
using StudentEventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace StudentEventManagement.Infrastructure.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegistrationDto> RegisterParticipantAsync(RegistrationDto dto)
        {
            // Check for duplicate
            bool exists = await _context.Registrations.AnyAsync(r => r.ParticipantId == dto.ParticipantId && r.EventId == dto.EventId);
            if (exists)
                throw new Exception("Participant already registered for this event.");

            var registration = new Registration
            {
                ParticipantId = dto.ParticipantId,
                EventId = dto.EventId,
                RegistrationDate = DateTime.UtcNow
            };

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            dto.Id = registration.Id;
            dto.RegisteredAt = registration.RegistrationDate;
            return dto;
        }

        public async Task<List<RegistrationDto>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                .Select(r => new RegistrationDto
                {
                    Id = r.Id,
                    EventId = r.EventId,
                    ParticipantId = r.ParticipantId,
                    RegisteredAt = r.RegistrationDate
                })
                .ToListAsync();
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null) return false;

            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
