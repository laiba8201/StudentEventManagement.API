using StudentEventManagement.Application.DTOs;

namespace StudentEventManagement.Application.Interfaces
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDto>> GetAllParticipantsAsync();
        Task<ParticipantDto> GetParticipantByIdAsync(int id);
        Task AddParticipantAsync(ParticipantDto participantDto);
        Task UpdateParticipantAsync(ParticipantDto participantDto);
        Task DeleteParticipantAsync(int id);
    }
}
