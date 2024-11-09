using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach_s_Log.DTO.LessonDTO;
using Microsoft.AspNetCore.Mvc;

namespace Coach_s_Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Lesson>>> GetLessons()
        {
            var groups = await _lessonService.GetAllLessons();

            return Ok(groups);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> CreateLesson([FromBody] LessonRequest lessonRequest)
        {
            var userId = await _lessonService.CreateLesson(lessonRequest.DateTime,lessonRequest.Coach,lessonRequest.Group);

            return Ok(userId);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteLesson(Guid id)
        {
            var userId = await _lessonService.DeleteLessonp(id);

            return Ok(userId);
        }
    }
}
