using Coach.Core.Interfaces;
using Coach_s_Log.DTO.CoachDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coach_s_Log.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService userService)
        {
            _coachService = userService;
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<List<CoachResponse>>> GetCoaches()
        {
            var coaches = await _coachService.GetAllUsers();

            var response = coaches.Select(b => new CoachResponse(b.Id, b.FullName, b.Email, b.PasswordHash));

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> Login([FromBody] CoachLoginRequest coachRequest)
        {
            var token = await _coachService.Login(coachRequest.Email, coachRequest.Password);

            HttpContext.Response.Cookies.Append("token", token);

            return Ok(token);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> Register([FromBody] CoachRegisterRequest coachRequest)
        {

            var userId = await _coachService.CreateUser(coachRequest.FullName,
                coachRequest.Email,
                coachRequest.Password);

            return Ok(userId);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] CoachRegisterRequest coachRequest)
        {
            var userId = await _coachService.UpdateUser(id, coachRequest.FullName, coachRequest.Email);

            return Ok(userId);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            var userId = await _coachService.DeleteUser(id);

            return Ok(userId);
        }
    }
}
