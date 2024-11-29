using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL.Repositories
{
    public class SportsmenRepository : ISportsmenRepository
    {
        private readonly CoachLogDbContext _context;

        public SportsmenRepository(CoachLogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sportsmen>> Get()
        {
            var sportsmenEntities = await _context.Sportsmens                
                .AsNoTracking()
                .ToListAsync();

            var sportsmens = sportsmenEntities
                .Select(b => Sportsmen.Create(b.Id, b.FullName).Sportsmen).ToList();

            return sportsmens;
        }        
        public async Task<Guid> Create(Sportsmen sportsmen)
        {
            var sportsmenEntity = new SportsmenEntity
            {
                Id = sportsmen.Id,
                UserName = sportsmen.UserName,
                PasswordHash = sportsmen.PasswordHash,
                FullName = sportsmen.FullName,                
                Category = sportsmen.Category,
                Beginnning = sportsmen.Beginnning,                                                 
            };

            await _context.Sportsmens.AddAsync(sportsmenEntity);
            await _context.SaveChangesAsync();

            return sportsmenEntity.Id;
        }

        public async Task<Guid> UpdateSelf(Guid id, bool isMale, DateOnly birthday, string address, string contacts)
        {
            await _context.Sportsmens
                 .Where(b => b.Id == id)
                 .ExecuteUpdateAsync(s => s                     
                     .SetProperty(b => b.IsMale, b => isMale)
                     .SetProperty(b => b.Birthday, b => birthday)                     
                     .SetProperty(b => b.Address, b => address)
                     .SetProperty(b => b.Contacts, b => contacts));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Sportsmens
                 .Where(b => b.Id == id)
                 .ExecuteDeleteAsync();

            return id;
        }

        public async Task<Sportsmen> GetByUserName(string userName)
        {
            var userEntity = await _context.Sportsmens
                .Include(s => s.PayInformation)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == userName) ?? throw new Exception("No user!");

            var sportsmen = Sportsmen.Create(userEntity.Id, userEntity.UserName).Sportsmen;
            return sportsmen;
        }

        public async Task CreateAttendance(List<Lesson> lessons)
        {
            var groupId = lessons.FirstOrDefault().GruopId;
            var sports = await _context.Sportsmens
               .Include(s => s.Attendance)
               .Where(b => b.Group.Id == groupId)
               .ToListAsync();

            var list = new List<AttendanceEntity>();
            foreach (var sport in sports)
            {
                
                foreach (var lesson in lessons)
                {
                    list.Add(new AttendanceEntity { Id = Guid.NewGuid(), Date = lesson.Date, Sportsmen = sport });
                }               
            }
                                                             
            await _context.Attendances.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }

        public async Task<(string name, List<Attendance> attendance)> GetAttendance(Guid sportsmenId)
        {
            var sportsmen = await _context.Sportsmens.Where(s => s.Id == sportsmenId)
                .Include(s => s.Attendance)
                .Include(s => s.Group)
                .FirstOrDefaultAsync();
            var groupName = sportsmen.Group.Name;
            var attendance = new List<Attendance>();
            foreach (var item in sportsmen.Attendance)
            {
                attendance.Add(Attendance.Create(item.Id,item.Date,item.IsPresent));
            }

            return (groupName, attendance);
        }

        public async Task GhangeAttendance(List<Attendance> attendances)
        {
           foreach(var attendance in attendances)
           {
              var les = await _context.Attendances
                       .FirstOrDefaultAsync(a => a.SportstmenId == attendance.SportsmenId && a.Date == attendance.Date);
              les.IsPresent = attendance.IsPresent;
           }  
           
          await  _context.SaveChangesAsync();
        }
    }
}
