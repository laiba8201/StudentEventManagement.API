  using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;
using StudentEventManagement.Domain.Entities;
using StudentEventManagement.Infrastructure.Persistence;
using System;

namespace StudentEventManagement.Infrastructure.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)

        {
            _context = context;
        }

        public async Task<List<FeedbackDto>> GetAllFeedbacksAsync()
        {
            return _context.Feedbacks
                .Select(f => new FeedbackDto
                {
                    Id = f.Id,
                    Rating = f.Rating,
                    Comment = f.Comment,
                    EventId = f.EventId
                }).ToList();
        }

        public async Task<FeedbackDto> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return null;

            return new FeedbackDto
            {
                Id = feedback.Id,
                Rating = feedback.Rating,
                Comment = feedback.Comment,
                EventId = feedback.EventId
            };
        }

        public async Task<FeedbackDto> CreateFeedbackAsync(FeedbackDto dto)
        {
            var feedback = new Feedback
            {
                Rating = dto.Rating,
                Comment = dto.Comment,
                EventId = dto.EventId
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            dto.Id = feedback.Id;
            return dto;
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return false;

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
