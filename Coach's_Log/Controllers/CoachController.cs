using Coach.Core.Interfaces;
using Coach_s_Log.DTO.CoachDTO;
using Microsoft.AspNetCore.Authorization;
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
            var coaches = await _coachService.GetAllCoaches();

            var response = coaches.Select(b => new CoachResponse(b.Id, b.FullName, b.Email, b.PasswordHash));

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> LoginCoach([FromBody] CoachLoginRequest coachRequest)
        {
            var data = await _coachService.Login(coachRequest.Email, coachRequest.Password);
            var token = data.Item1;
            var id = data.Item2;

            HttpContext.Response.Cookies.Append("token", token);

            return Ok(id);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> RegisterCoach([FromBody] CoachRegisterRequest coachRequest)
        {

            var userId = await _coachService.CreateCoach(coachRequest.FullName,
                coachRequest.Email,
                coachRequest.Password);

            return Ok();
        }
        
        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> UpdateCoach(Guid id, [FromBody] CoachRegisterRequest coachRequest)
        {
            var userId = await _coachService.UpdateCoach(id, coachRequest.FullName, coachRequest.Email);

            return Ok(userId);
        }
        
        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteCoach(Guid id)
        {
            var userId = await _coachService.DeleteCoach(id);

            return Ok(userId);
        }
    }
}
