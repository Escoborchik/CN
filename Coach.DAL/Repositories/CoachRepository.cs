﻿using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace Coach.DAL.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly CoachLogDbContext _context;

        public CoachRepository(CoachLogDbContext context)
        {
            _context = context;
        }

        public async Task<List<CoachModel>> Get()
        {
            var coachEntities = await _context.Coaches
                .AsNoTracking()
                .ToListAsync();

            var coaches = coachEntities
                .Select(b => CoachModel.Create(b.Id, b.FullName,b.Email,b.PasswordHash)
                .Coach)
                .ToList();

            return coaches;
        }

        public async Task<List<Sportsmen>> GetCoachSportsmens(Guid CoachId)
        {
            var coach = await _context.Coaches.Where(c => c.Id == CoachId).Include(c => c.Sportsmens).FirstOrDefaultAsync();
                

            var sportsmens = coach.Sportsmens
                .Select(b => Sportsmen.Create(b.Id, b.FullName)
                .Sportsmen)
                .ToList();

            return sportsmens;
        }

        public async Task<Guid> Create(CoachModel coach)
        {
            var coachEntity = new CoachEntity
            {
                Id = coach.Id,
                FullName = coach.FullName,
                Email = coach.Email,
                PasswordHash = coach.PasswordHash,               
            };

            await _context.Coaches.AddAsync(coachEntity);
            await _context.SaveChangesAsync();

            return coachEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string fullName, string email)
        {
            await _context.Coaches
                 .Where(b => b.Id == id)
                 .ExecuteUpdateAsync(s => s
                     .SetProperty(b => b.FullName, b => fullName)
                     .SetProperty(b => b.Email, b => email));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Coaches
                 .Where(b => b.Id == id)
                 .ExecuteDeleteAsync();

            return id;
        }

        public async Task<CoachModel> GetByEmail(string email)
        {
            var userEntity = await _context.Coaches
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("No user!");

            var coach = CoachModel.Create(userEntity.Id, userEntity.FullName, userEntity.Email, userEntity.PasswordHash).Coach;
            return coach;
        }
    }
}
