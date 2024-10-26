using Coach.Core.Interfaces;
using Coach_s_Log.DTO.PayInformationDTO;
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

            var response = sportsmens.Select(sportsmen => new SportsmenResponse(sportsmen.FullName, sportsmen.IsMale, sportsmen.Birthday,
                sportsmen.Category, sportsmen.Beginnning, sportsmen.Address, sportsmen.Contacts,
                new PayInformationResponse(sportsmen.PayInformation.Summary, sportsmen.PayInformation.Overpayment,
                sportsmen.PayInformation.Debt, sportsmen.PayInformation.Images),
                sportsmen.Attendance));

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SportsmenResponse>> Login([FromBody] SportsmenLoginRequest sportsmenRequest)
        {
            var sportsmen = await _sportsmenService.Login(sportsmenRequest.UserName, sportsmenRequest.Password);            

            return Ok(new SportsmenResponse(sportsmen.FullName, sportsmen.IsMale, sportsmen.Birthday, sportsmen.Category,
                sportsmen.Beginnning, sportsmen.Address, sportsmen.Contacts,
                new PayInformationResponse(sportsmen.PayInformation.Summary, sportsmen.PayInformation.Overpayment,
                sportsmen.PayInformation.Debt, sportsmen.PayInformation.Images), sportsmen.Attendance));
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
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] SportsmenRegisterRequest sportsmenRequest)
        {
            var userId = await _sportsmenService.UpdateUser(id, sportsmenRequest.FullName, sportsmenRequest.IsMale, sportsmenRequest.Birthday,
                sportsmenRequest.Category, sportsmenRequest.Beginnning, sportsmenRequest.Address, sportsmenRequest.Contacts);
            return Ok(userId);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var userId = await _sportsmenService.DeleteUser(id);

            return Ok(userId);
        }
    }
}
