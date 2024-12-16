using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IGroupRepository
    {
        Task<Guid> Create(Group group);
        Task<Guid> Delete(Guid id);
        Task<List<Group>> Get();
        Task<Guid> Update(Guid id, string name, List<Guid> sportsmens);
        Task AddSportsmenToGroup(Guid groupId, List<Guid> Sportsmen);
        Task<Group> GetGroup(Guid groupId);
    }
}