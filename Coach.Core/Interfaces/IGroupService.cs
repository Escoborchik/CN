using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public interface IGroupService
    {
        Task<Guid> CreateGroup(string name, short price, List<Guid> sportsmens);
        Task<Guid> DeleteGroup(Guid id);
        Task<List<Group>> GetAllGroupes();
        Task<Guid> UpdateGroup(Guid id, string name, short price, List<Guid> sportsmens);
    }
}