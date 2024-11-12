using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> Create(List<Lesson> lessons);
        Task<Guid> Delete(Guid id);
        Task<List<Lesson>> Get();
    }
}