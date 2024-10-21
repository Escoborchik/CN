using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ISportsmenService
    {
        Task<Guid> CreateUser(string userName, string password, string fullName, bool isMale, DateTime birthday, int category, DateTime beginnning, string address, string contacts);
        Task<Guid> DeleteUser(Guid id);
        Task<List<Sportsmen>> GetAllUsers();
        Task<Sportsmen> Login(string userName, string password);
        Task<Guid> UpdateUser(Guid id, string fullName, bool isMale, DateTime birthday, int category, DateTime beginnning, string address, string contacts);
    }
}