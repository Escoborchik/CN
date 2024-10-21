using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class SportsmenService : ISportsmenService
    {
        private readonly ISportsmenRepository _sportsmenRepository;

        public SportsmenService(ISportsmenRepository sportsmenRepository)
        {
            _sportsmenRepository = sportsmenRepository;
        }

        public async Task<List<Sportsmen>> GetAllUsers()
        {
            return await _sportsmenRepository.Get();
        }

        public async Task<Guid> CreateUser(string userName, string password, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts)
        {
            var sportsmen = Sportsmen.Create(
               Guid.NewGuid(), userName,
               password, fullName,
               isMale, birthday,
               category, beginnning,
               address, contacts
            );

            if (string.IsNullOrEmpty(sportsmen.Error))
            {
                return await _sportsmenRepository.Create(sportsmen.Sportsmen);
            }
            else
            {
                throw new Exception(sportsmen.Error);
            }


        }

        public async Task<Sportsmen> Login(string userName, string password)
        {
            var sportsmen = await _sportsmenRepository.GetByUserName(userName);

            var result = password.Equals(sportsmen.PasswordHash);

            if (!result)
            {
                throw new Exception("Fail to login");
            }

            return sportsmen;
        }

        public async Task<Guid> UpdateUser(Guid id, string fullName,
            bool isMale, DateTime birthday, int category, DateTime beginnning,
            string address, string contacts)
        {
            return await _sportsmenRepository.Update(id, fullName, isMale, birthday, category, beginnning, address, contacts);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _sportsmenRepository.Delete(id);
        }
    }
}
