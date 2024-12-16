using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ICoachRepository
    {
        Task<Guid> Create(CoachModel coach);
        Task<Guid> Delete(Guid id);
        Task<List<CoachModel>> Get();
        Task<CoachModel> GetByEmail(string email);
        Task<Guid> Update(Guid id, string fullName, string email);
        Task<List<Sportsmen>> GetCoachSportsmens(Guid CoachId);
    }
}