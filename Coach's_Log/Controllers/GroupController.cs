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


        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> Create(Guid id, [FromBody] GroupRequest groupRequest)
        {
            var userId = await _groupService.CreateGroup(groupRequest.Name,groupRequest.Price,groupRequest.Sportsmens);

            return Ok(userId);
        }



        [HttpPut("[action]")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] GroupRequest groupRequest)
        {
            var userId = await _groupService.UpdateGroup(id, groupRequest.Name, groupRequest.Price, groupRequest.Sportsmens);

            return Ok(userId);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var userId = await _groupService.DeleteGroup(id);

            return Ok(userId);
        }
    }
}
