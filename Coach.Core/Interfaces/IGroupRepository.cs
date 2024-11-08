using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IGroupRepository
    {
        Task<Guid> Create(Group group);
        Task<Guid> Delete(Guid id);
        Task<List<Group>> Get();
        Task<Guid> Update(Guid id, string name, short price, List<Guid> sportsmens);
    }
}