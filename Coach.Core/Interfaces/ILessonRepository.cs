using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ILessonRepository
    {
        Task<Guid> Create(Lesson lesson);
        Task<Guid> Delete(Guid id);
        Task<List<Lesson>> Get();
    }
}