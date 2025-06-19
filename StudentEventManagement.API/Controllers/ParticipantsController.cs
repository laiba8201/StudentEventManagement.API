using Microsoft.AspNetCore.Mvc;
using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;

namespace StudentEventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _participantService.GetAllParticipantsAsync();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);
            return participant == null ? NotFound() : Ok(participant);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ParticipantDto dto)
        {
            await _participantService.AddParticipantAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ParticipantDto dto)
        {
            dto.Id = id;
            await _participantService.UpdateParticipantAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _participantService.DeleteParticipantAsync(id);
            return NoContent();
        }
    }
}
