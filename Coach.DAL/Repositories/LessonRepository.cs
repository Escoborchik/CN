using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly CoachLogDbContext _context;

        public LessonRepository(CoachLogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> Get()
        {
            var lessonEntities = await _context.Lessons
                .AsNoTracking()
                .ToListAsync();

            var lessons = lessonEntities
                .Select(b => Lesson.Create(b.Id, b.DateTime, b.Coach, b.Gruop).Lesson).ToList();


            return lessons;
        }

        public async Task<Guid> Create(Lesson lesson)
        {
            var lessonEntity = new LessonEntity
            {
                Id = lesson.Id,
                DateTime = lesson.DateTime,
                Coach = lesson.Coach,
                Gruop = lesson.Gruop,

            };

            await _context.Lessons.AddAsync(lessonEntity);
            await _context.SaveChangesAsync();

            return lessonEntity.Id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Lessons
                 .Where(b => b.Id == id)
                 .ExecuteDeleteAsync();

            return id;
        }
    }
}
