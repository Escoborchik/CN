using Coach.Core.Interfaces;
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
        public async Task<ActionResult<List<LessonResponse>>> GetLessons()
        {
            var lessons = await _lessonService.GetAllLessons();
            var answer = lessons.Select(l => new LessonResponse(l.Price,l.Time,l.Date,l.Group.Name,l.Coach.FullName)).ToList();
            return Ok(answer);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<LessonResponse>>> GetCoachLessons(Guid coachId)
        {
            var lessons = await _lessonService.GetCoachLessons(coachId);
            var answer = lessons.Select(l => new LessonResponse(l.Price, l.Time, l.Date, l.Group.Name, l.Coach.FullName)).ToList();
            return Ok(answer);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> CreateLesson([FromBody] LessonRequest lessonRequest)
        {
            var userId = await _lessonService.CreateLesson(lessonRequest.CoachId, lessonRequest.GroupId,
                lessonRequest.Price, lessonRequest.Date, lessonRequest.Time);

            return Ok(userId);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Guid>> DeleteLesson(Guid id)
        {
            var userId = await _lessonService.DeleteLesson(id);

            return Ok(userId);
        }
    }
}
