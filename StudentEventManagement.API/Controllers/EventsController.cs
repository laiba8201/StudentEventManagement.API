using Microsoft.AspNetCore.Mvc;
using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;

namespace StudentEventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var e = await _eventService.GetEventByIdAsync(id);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventDto dto)
        {
            var created = await _eventService.CreateEventAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventDto dto)
        {
            var success = await _eventService.UpdateEventAsync(id, dto);
            if (!success)
                return NotFound("Event not found");

            return Ok("Event updated successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _eventService.DeleteEventAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _eventService.SearchEventsAsync(query);
            return Ok(results);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterByDate()
        {
            var results = await _eventService.FilterEventsByDateAsync();
            return Ok(results);
        }

    }
}
