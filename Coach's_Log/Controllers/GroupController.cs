using Coach.BAL.Services;
using Coach_s_Log.DTO.GroupDTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Coach_s_Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Group>>> GetGroupes()
        {
            var groups = await _groupService.GetAllGroupes();            

            return Ok(groups);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Group>>> GetCoachesGroupes(Guid coachId)
        {
            var groups = await _groupService.GetAllCoachGroupes(coachId);

            return Ok(groups);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<Group>> CreateGroup([FromBody] GroupRequest groupRequest)
        {
            var group = await _groupService.CreateGroup(groupRequest.CoachId, groupRequest.Name);

            return Ok(group);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> AddSportmenToGroup([FromBody] GroupAddSportsmenRequest groupRequest)
        {
            await _groupService.AddSportsmenToGroup(groupRequest.GroupId, groupRequest.Sportsmen);

            return Ok();          
        }



        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> UpdateGroup([FromBody] GroupUpdateRquest groupUpdateRquest)
        {
            var userId = await _groupService.UpdateGroup(groupUpdateRquest.groupId, groupUpdateRquest.name, groupUpdateRquest.sportsmen);

            return Ok(userId);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteGroup(Guid id)
        {
            var userId = await _groupService.DeleteGroup(id);

            return Ok(userId);
        }
    }
}
