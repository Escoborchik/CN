using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface ISportsmenService
    {
        Task<Guid> CreateUser(string userName, string password, string fullName, int category, DateOnly beginnning);
        Task<Guid> Delete(Guid id);
        Task<List<Sportsmen>> GetAllUsers();
        Task<(Sportsmen,string)> Login(string userName, string password);
        Task<Guid> UpdateSelf(Guid id, bool isMale, DateOnly birthday, string address, string contacts);
    }
}