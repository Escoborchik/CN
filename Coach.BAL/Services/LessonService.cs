using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;

        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _lessonRepository.Get();
        }

        public async Task<Guid> CreateLesson(DateTime dateTime, Guid coach, Guid group)
        {

            var lesson = Lesson.Create(
               Guid.NewGuid(),
               dateTime,
               coach,
               group);

            if (string.IsNullOrEmpty(lesson.Error))
            {
                return await _lessonRepository.Create(lesson.Lesson);
            }
            else
            {
                throw new Exception(lesson.Error);
            }
        }

        public async Task<Guid> DeleteLessonp(Guid id)
        {
            return await _lessonRepository.Delete(id);

        }
    }
}
