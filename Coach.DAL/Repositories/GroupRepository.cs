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
            var gruopEntities = await _context.Gruops
                .AsNoTracking()
                .ToListAsync();

            var groups = gruopEntities
                .Select(b => Group.Create(b.Id, b.Name, b.Price,
                b.Sportsmens.Select(s => s.Id)
                .ToList()).Group).ToList();


            return groups;
        }

        public async Task<Guid> Create(Group group)
        {
            var groupEntity = new GroupEntity
            {
                Id = group.Id,
                Name = group.Name,
                Price = group.Price
            };
            await _context.Gruops.AddAsync(groupEntity);
            await _context.Sportsmens.Where(s => group.Sportsmens.Contains(s.Id)).ExecuteUpdateAsync(
                b => b.SetProperty(s => s.Gruop, s => groupEntity));
            await _context.SaveChangesAsync();

            return groupEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, short price, List<Guid> sportsmens)
        {
            var sports = _context.Sportsmens.Where(s => sportsmens.Contains(s.Id)).ToList();
            await _context.Gruops
                 .Where(b => b.Id == id)
                 .ExecuteUpdateAsync(s => s
                     .SetProperty(b => b.Name, b => name)
                     .SetProperty(b => b.Price, b => price)
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
