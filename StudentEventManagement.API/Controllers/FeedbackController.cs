using Microsoft.AspNetCore.Mvc;
using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;

namespace StudentEventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
                return NotFound();
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FeedbackDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  // 👈 this is the new line

            try
            {
                var result = await _feedbackService.CreateFeedbackAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _feedbackService.DeleteFeedbackAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
