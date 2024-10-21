using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ISportsmenRepository
    {
        Task<Guid> Create(Sportsmen sportsmen);
        Task<Guid> Delete(Guid id);
        Task<List<Sportsmen>> Get();
        Task<Sportsmen> GetByUserName(string userName);
        Task<Guid> Update(Guid id, string fullName, bool isMale, DateTime birthday, int category, DateTime beginnning, string address, string contacts);
    }
}