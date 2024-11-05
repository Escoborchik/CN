using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ICoachService
    {
        Task<Guid> CreateCoach(string fullName, string email, string password);
        Task<Guid> DeleteCoach(Guid id);
        Task<List<CoachModel>> GetAllCoaches();
        Task<(string,Guid)> Login(string email, string password);
        Task<Guid> UpdateCoach(Guid id, string userName, string email);
    }
}