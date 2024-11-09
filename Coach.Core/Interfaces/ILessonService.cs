using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ILessonService
    {
        Task<Guid> CreateLesson(DateTime dateTime, Guid coach, Guid group);
        Task<Guid> DeleteLessonp(Guid id);
        Task<List<Lesson>> GetAllLessons();
    }
}