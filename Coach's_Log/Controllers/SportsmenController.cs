using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach_s_Log.DTO.SportsmenDTO;
using Microsoft.AspNetCore.Mvc;

namespace Coach_s_Log.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SportsmenController : ControllerBase
    {
        private readonly ISportsmenService _sportsmenService;
        private readonly IDataGenerator _dataGenerator;

        public SportsmenController(ISportsmenService userService, IDataGenerator dataGenerator)
        {
            _sportsmenService = userService;
            _dataGenerator = dataGenerator;
        }

        [HttpPost("[action]")]
        public ActionResult<DataEntry> MakeDataEntry([FromBody] string fullName)
        {
            var answer = _dataGenerator.Generate(fullName);
            return Ok(new DataEntry(answer.Item1, answer.Item2));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SportsmenResponse>> LoginSportsmen([FromBody] SportsmenLoginRequest sportsmenRequest)
        {
            var data = await _sportsmenService.Login(sportsmenRequest.UserName, sportsmenRequest.Password);
            var sportsmen = data.Item1;
            var token = data.Item2;

            HttpContext.Response.Cookies.Append("token", token);

            return Ok(new SportsmenResponse(sportsmen.Id, sportsmen.FullName));
        }



        [HttpGet("[action]")]
        public async Task<ActionResult<List<SportsmenResponse>>> GetSportsmens()
        {
            var sportsmens = await _sportsmenService.GetAllUsers();

            var response = sportsmens.Select(s => new SportsmenResponse(s.Id, s.FullName));

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<(string name, List<Attendance>)>> GetAttendance(Guid sportsmanId)
        {             
            var tuple = await _sportsmenService.GetAttendance(sportsmanId);           
            return Ok(tuple);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> RegisterSportsmen([FromBody] SportsmenRegisterRequest sportsmenRequest)
        {
            await _sportsmenService.CreateUser(sportsmenRequest.UserName, sportsmenRequest.Password, sportsmenRequest.FullName,
                sportsmenRequest.Category,
            sportsmenRequest.Beginnning);
            return Ok();
        }


        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> UpdateSelf([FromBody] SportsmenUpdateRequest sportsmenRequest)
        {
            await _sportsmenService.UpdateSelf(sportsmenRequest.Id, sportsmenRequest.IsMale, sportsmenRequest.Birthday,
               sportsmenRequest.Address, sportsmenRequest.Contacts);
            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteSportsmen(Guid id)
        {
            var userId = await _sportsmenService.Delete(id);

            return Ok(userId);
        }
    }
}
