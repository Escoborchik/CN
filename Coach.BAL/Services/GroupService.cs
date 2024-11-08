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

        public async Task<Guid> CreateGroup(string name, short price, List<Guid> sportsmens)
        {


            var group = Group.Create(
               Guid.NewGuid(),
               name,
               price,
               sportsmens);

            if (string.IsNullOrEmpty(group.Error))
            {
                return await _groupRepository.Create(group.Group);
            }
            else
            {
                throw new Exception(group.Error);
            }
        }

        public async Task<Guid> UpdateGroup(Guid id, string name, short price, List<Guid> sportsmens)
        {
            return await _groupRepository.Update(id, name, price, sportsmens);
        }

        public async Task<Guid> DeleteGroup(Guid id)
        {
            return await _groupRepository.Delete(id);

        }
    }
}
