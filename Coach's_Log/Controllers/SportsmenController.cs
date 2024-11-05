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
            return Ok(new DataEntry(answer.Item1,answer.Item2));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SportsmenResponse>> Login([FromBody] SportsmenLoginRequest sportsmenRequest)
        {
            var data = await _sportsmenService.Login(sportsmenRequest.UserName, sportsmenRequest.Password);
            var sportsmen = data.Item1;
            var token = data.Item2;

            HttpContext.Response.Cookies.Append("token", token);
            
            return Ok(new SportsmenResponse(sportsmen.FullName, sportsmen.IsMale, sportsmen.Birthday, sportsmen.Category,
                sportsmen.Beginnning, sportsmen.Address, sportsmen.Contacts,
                new PayInformationResponse(sportsmen.PayInformation.Summary, sportsmen.PayInformation.Overpayment,
                sportsmen.PayInformation.Debt, sportsmen.PayInformation.Images), sportsmen.Attendance));
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
        public async Task<ActionResult<Guid>> Register([FromBody] SportsmenRegisterRequest sportsmenRequest)
        {
            await _sportsmenService.CreateUser(sportsmenRequest.UserName, sportsmenRequest.Password, sportsmenRequest.FullName,
                sportsmenRequest.Category,
            sportsmenRequest.Beginnning);
            return Ok();
        }


        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> UpdateSelf(Guid id, [FromBody] SportsmenUpdateRequest sportsmenRequest)
        {
            var userId = await _sportsmenService.UpdateSelf(id, sportsmenRequest.IsMale, sportsmenRequest.Birthday,
               sportsmenRequest.Address, sportsmenRequest.Contacts);
            return Ok(userId);
        }
        
        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var userId = await _sportsmenService.Delete(id);

            return Ok(userId);
        }
    }
}
