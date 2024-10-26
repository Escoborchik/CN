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
                .Include(s=> s.PayInformation)
                .AsNoTracking()
                .ToListAsync();

            var sportsmens = sportsmenEntities
                .Select(b => Sportsmen.Create(b.Id, b.UserName, b.PasswordHash, b.FullName, b.IsMale, b.Birthday,
                b.Category, b.Beginnning, b.Address, b.Contacts,
                PayInformation.Create(b.PayInformation.Id,b.PayInformation.Summary,
                b.PayInformation.Overpayment,b.PayInformation.Debt,b.PayInformation.Images).PayInformation,
                b.Attendance.Select(a => Attendance.Create(a.Date,a.IsPresent)).ToList()).Sportsmen)
                .ToList();

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
                IsMale = sportsmen.IsMale,
                Birthday = sportsmen.Birthday,
                Category = sportsmen.Category,
                Beginnning = sportsmen.Beginnning,
                Address = sportsmen.Address,
                Contacts = sportsmen.Contacts,
                PayInformation = new(),
                Attendance = []

            };

            await _context.Sportsmens.AddAsync(sportsmenEntity);
            await _context.SaveChangesAsync();

            return sportsmenEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts)
        {
            await _context.Sportsmens
                 .Where(b => b.Id == id)
                 .ExecuteUpdateAsync(s => s
                     .SetProperty(b => b.FullName, b => fullName)
                     .SetProperty(b => b.IsMale, b => isMale)
                     .SetProperty(b => b.Birthday, b => birthday)
                     .SetProperty(b => b.Category, b => category)
                     .SetProperty(b => b.Beginnning, b => beginnning)
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

            var sportsmen = Sportsmen.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.FullName,
                userEntity.IsMale, userEntity.Birthday, userEntity.Category, userEntity.Beginnning,
                userEntity.Address, userEntity.Contacts,
                PayInformation.Create(userEntity.PayInformation.Id, userEntity.PayInformation.Summary,
                userEntity.PayInformation.Overpayment, userEntity.PayInformation.Debt, userEntity.PayInformation.Images).PayInformation,
                userEntity.Attendance.Select(a => Attendance.Create(a.Date, a.IsPresent)).ToList()).Sportsmen;
            return sportsmen;
        }
    }
}
