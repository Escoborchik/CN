using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public interface IGroupService
    {
        Task<Group> CreateGroup(Guid coachId,string name);
        Task<Guid> DeleteGroup(Guid id);
        Task<List<Group>> GetAllGroupes();
        Task<List<Group>> GetAllCoachGroupes(Guid coachId);
        Task<Guid> UpdateGroup(Guid id, string name, List<Guid> sportsmens);
        Task AddSportsmenToGroup(Guid groupId, List<Guid> sportsmen);
    }
}