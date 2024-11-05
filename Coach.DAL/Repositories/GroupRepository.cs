using Coach.Core.Models;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL.Repositories
{
    //public class GroupRepository
    //{
    //    private readonly CoachLogDbContext _context;

    //    public GroupRepository(CoachLogDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<List<Group>> Get()
    //    {
    //        var gruopEntities = await _context.Gruops
    //            .AsNoTracking()
    //            .ToListAsync();

    //        var groups = gruopEntities
    //            .Select(b => Group.Create(b.Id, b.Name, b.Price, 
    //            b.Sportsmens.Select(s => Sportsmen.Create()).G)
    //            .ToList();

    //        return groups;
    //    }

    //    public async Task<Guid> Create(CoachModel coach)
    //    {
    //        var coachEntity = new CoachEntity
    //        {
    //            Id = coach.Id,
    //            FullName = coach.FullName,
    //            Email = coach.Email,
    //            PasswordHash = coach.PasswordHash,

    //        };

    //        await _context.Coaches.AddAsync(coachEntity);
    //        await _context.SaveChangesAsync();

    //        return coachEntity.Id;
    //    }

    //    public async Task<Guid> Update(Guid id, string fullName, string email)
    //    {
    //        await _context.Coaches
    //             .Where(b => b.Id == id)
    //             .ExecuteUpdateAsync(s => s
    //                 .SetProperty(b => b.FullName, b => fullName)
    //                 .SetProperty(b => b.Email, b => email));

    //        return id;
    //    }

    //    public async Task<Guid> Delete(Guid id)
    //    {
    //        await _context.Coaches
    //             .Where(b => b.Id == id)
    //             .ExecuteDeleteAsync();

    //        return id;
    //    }         
    //}
}
