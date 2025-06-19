using StudentEventManagement.Application.DTOs;

namespace StudentEventManagement.Application.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationDto> RegisterParticipantAsync(RegistrationDto registrationDto);
        Task<List<RegistrationDto>> GetAllRegistrationsAsync();
        Task<bool> DeleteRegistrationAsync(int id);
    }
}
