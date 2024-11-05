using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ISportsmenRepository
    {
        Task<Guid> Create(Sportsmen sportsmen);
        Task<Guid> Delete(Guid id);
        Task<List<Sportsmen>> Get();
        Task<Sportsmen> GetByUserName(string userName);
        Task<Guid> UpdateSelf(Guid id, bool isMale, DateOnly birthday, string address, string contacts);
    }
}