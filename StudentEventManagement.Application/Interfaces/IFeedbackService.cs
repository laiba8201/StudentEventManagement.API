using StudentEventManagement.Application.DTOs;

namespace StudentEventManagement.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<List<FeedbackDto>> GetAllFeedbacksAsync();
        Task<FeedbackDto> GetFeedbackByIdAsync(int id);
        Task<FeedbackDto> CreateFeedbackAsync(FeedbackDto dto);
        Task<bool> DeleteFeedbackAsync(int id);
    }
}
