using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ICoachService
    {
        Task<Guid> CreateUser(string fullName, string email, string password);
        Task<Guid> DeleteUser(Guid id);
        Task<List<CoachModel>> GetAllUsers();
        Task<string> Login(string email, string password);
        Task<Guid> UpdateUser(Guid id, string userName, string email);
    }
}