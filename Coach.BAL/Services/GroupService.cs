using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;

        }

        public async Task<List<Group>> GetAllGroupes()
        {
            return await _groupRepository.Get();
        }

        public async Task<List<Group>> GetAllCoachGroupes(Guid coachId)
        {
            var groups = await _groupRepository.Get();
            return groups.Where(g => g.CoachId == coachId).ToList();
        }       

        public async Task<Group> CreateGroup(Guid coachId, string name)
        {


            var group = Group.Create(
               Guid.NewGuid(),
               coachId,
               name);

            if (string.IsNullOrEmpty(group.Error))
            {
                await _groupRepository.Create(group.Group);
                return group.Group;
            }
            else
            {
                throw new Exception(group.Error);
            }
        }

        public async Task AddSportsmenToGroup(Guid groupId, List<Guid> sportsmen)
        {
           await  _groupRepository.AddSportsmenToGroup(groupId, sportsmen);
        }


        public async Task<Guid> UpdateGroup(Guid id, string name, List<Guid> sportsmens)
        {
            return await _groupRepository.Update(id, name, sportsmens);
        }

        public async Task<Guid> DeleteGroup(Guid id)
        {
            return await _groupRepository.Delete(id);

        }

        
    }
}
