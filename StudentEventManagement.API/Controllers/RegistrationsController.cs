using Microsoft.AspNetCore.Mvc;
using StudentEventManagement.Application.DTOs;
using StudentEventManagement.Application.Interfaces;

namespace StudentEventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  // 👈 this is the new line

            try
            {
                var result = await _registrationService.RegisterParticipantAsync(dto);
                return Ok(result); // return the registration data
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            return Ok(registrations);
        }
    }
}
