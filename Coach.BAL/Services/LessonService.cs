using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ISportsmenService _sportsmenService;

        public LessonService(ILessonRepository lessonRepository, ISportsmenService sportsmenService)
        {
            _lessonRepository = lessonRepository;
            _sportsmenService = sportsmenService;

        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _lessonRepository.Get();
        }

        public async Task<List<Lesson>> GetCoachLessons(Guid coachId)
        {
            var lessons =  await _lessonRepository.Get();
            return lessons.Where(l => l.Coach.Id == coachId).ToList();
        }

        public async Task<List<Lesson>> CreateLesson(Guid coachId, Guid groupId, short price, DateOnly date, TimeOnly time)
        {
            List<Lesson> listLessons = [];
            for (int i = 0; i < 25; i++)
            {
                var lesson = Lesson.Create(
               Guid.NewGuid(),
               price,
               time,
               date,
               coachId,
               groupId);

                listLessons.Add(lesson.Lesson);
                date = date.AddDays(7);
            }

            await _sportsmenService.CreateAttendance(listLessons);

            return await _lessonRepository.Create(listLessons);
        }

        public async Task<Guid> DeleteLesson(Guid id)
        {
            return await _lessonRepository.Delete(id);

        }
    }
}
