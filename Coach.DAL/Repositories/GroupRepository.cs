using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CoachLogDbContext _context;

        public GroupRepository(CoachLogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> Get()
        {
            var gruopEntities = await _context.Gruops.Include(g => g.Sportsmens)
                .AsNoTracking()
                .ToListAsync();

            var groups = gruopEntities
                .Select(b => Group.Create(b.Id, b.CoachId, b.Name,
                b.Sportsmens.Select(s => Sportsmen.Create(s.Id, s.FullName).Sportsmen).ToList()).Group).ToList();                

            return groups;
        }

        public async Task AddSportsmenToGroup(Guid groupId, List<Guid> Sportsmen)
        {
            var groupEntity = await _context.Gruops.FirstOrDefaultAsync(g => g.Id == groupId);

            var sportsmenEntity = await _context.Sportsmens.Where(s => Sportsmen.Contains(s.Id)).ToListAsync();

            foreach (var sportsman in sportsmenEntity)
            {
                sportsman.Group = groupEntity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Guid> Create(Group group)
        {
            var coach = await _context.Coaches.FirstOrDefaultAsync(c => c.Id == group.CoachId);
            var groupEntity = new GroupEntity
            {
                Id = group.Id,
                CoachId = group.CoachId,
                Coach = coach,
                Name = group.Name,
            };

            await _context.Gruops.AddAsync(groupEntity);
            await _context.SaveChangesAsync();

            return groupEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, List<Guid> sportsmens)
        {
            var sports = await _context.Sportsmens.Where(s => sportsmens.Contains(s.Id)).ToListAsync();
            await _context.Gruops
                 .Where(b => b.Id == id)
                 .ExecuteUpdateAsync(s => s
                     .SetProperty(b => b.Name, b => name)
                     .SetProperty(b => b.Sportsmens, sports));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Gruops
                 .Where(b => b.Id == id)
                 .ExecuteDeleteAsync();

            return id;
        }
    }
}
