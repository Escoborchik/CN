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
                .Include(l => l.Gruop)
                .Include(l => l.Coach)
                .AsNoTracking()
                .ToListAsync();

            var lessons = lessonEntities
                .Select(l => Lesson.Create(l.Id,l.Price,l.Time,l.Date,
                Group.Create(l.Gruop.Id,l.Gruop.CoachId,l.Gruop.Name).Group,
                CoachModel.Create(l.Coach.Id,l.Coach.FullName,l.Coach.Email,l.Coach.PasswordHash).Coach).Lesson).ToList();

            return lessons;
        }

        public async Task<List<Lesson>> Create(List<Lesson> lessons)
        {
            List<LessonEntity> list = [];
            var lesson = lessons.FirstOrDefault();
            var coachId = lesson.CoachId;
            var groupId = lesson.GruopId;
            var coach = await _context.Coaches.FirstOrDefaultAsync(c => c.Id == coachId);
            var group = await _context.Gruops.FirstOrDefaultAsync(c => c.Id == groupId);      

            foreach (var item in lessons) 
            {
                var lessonEntity = new LessonEntity
                {
                    Id = item.Id,
                    Price = item.Price,
                    Time = item.Time,
                    Date = item.Date,                    
                    Coach = coach,
                    Gruop = group,
                };

                list.Add(lessonEntity);
            }
            

            await _context.Lessons.AddRangeAsync(list);
            await _context.SaveChangesAsync();

            return lessons;
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
