using Coach.Core.Interfaces;
using Coach_s_Log.DTO.SportsmenDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coach_s_Log.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SportsmenController : ControllerBase
    {
        private readonly ISportsmenService _sportsmenService;

        public SportsmenController(ISportsmenService userService)
        {
            _sportsmenService = userService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<SportsmenResponse>>> GetSportsmens()
        {
            var sportsmens = await _sportsmenService.GetAllUsers();

            var response = sportsmens.Select(b => new SportsmenResponse(b.FullName,b.IsMale,b.Birthday,b.Category,
                b.Beginnning,b.Address,b.Contacts));

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SportsmenResponse>> Login([FromBody] SportsmenLoginRequest sportsmenRequest)
        {
            var sportsmen = await _sportsmenService.Login(sportsmenRequest.UserName, sportsmenRequest.Password);            

            return Ok(new SportsmenResponse(sportsmen.FullName, sportsmen.IsMale, sportsmen.Birthday, sportsmen.Category,
                sportsmen.Beginnning, sportsmen.Address, sportsmen.Contacts));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> Register([FromBody] SportsmenRegisterRequest sportsmenRequest)
        {
            var userId = await _sportsmenService.CreateUser(sportsmenRequest.UserName,sportsmenRequest.Password, sportsmenRequest.FullName,
                sportsmenRequest.IsMale, sportsmenRequest.Birthday, sportsmenRequest.Category,
            sportsmenRequest.Beginnning, sportsmenRequest.Address, sportsmenRequest.Contacts);
            return Ok(userId);
        }
        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] SportsmenRegisterRequest sportsmenRequest)
        {
            var userId = await _sportsmenService.UpdateUser(id, sportsmenRequest.FullName, sportsmenRequest.IsMale, sportsmenRequest.Birthday,
                sportsmenRequest.Category, sportsmenRequest.Beginnning, sportsmenRequest.Address, sportsmenRequest.Contacts);
            return Ok(userId);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            var userId = await _sportsmenService.DeleteUser(id);

            return Ok(userId);
        }
    }
}
