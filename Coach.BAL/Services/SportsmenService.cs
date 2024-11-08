using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class SportsmenService : ISportsmenService
    {
        private readonly ISportsmenRepository _sportsmenRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTProvider _jwtprovider;

        public SportsmenService(ISportsmenRepository sportsmenRepository, IPasswordHasher passwordHasher, IJWTProvider jwtprovider)
        {
            _sportsmenRepository = sportsmenRepository;
            _passwordHasher = passwordHasher;
            _jwtprovider = jwtprovider;
        }

        public async Task<List<Sportsmen>> GetAllUsers()
        {
            return await _sportsmenRepository.Get();
        }

        public async Task<Guid> CreateUser(string userName, string password,
            string fullName, int category, DateOnly beginnning)
        {
            var hashPassword = _passwordHasher.Generate(password);

            var sportsmen = Sportsmen.Create(
               Guid.NewGuid(), userName,
               hashPassword, fullName,
               false, DateOnly.MinValue,
               category, beginnning,
               "", "", null, null,null
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

        public async Task<(Sportsmen,string)> Login(string userName, string password)
        {
            var sportsmen = await _sportsmenRepository.GetByUserName(userName);

            var result = _passwordHasher.Verify(password, sportsmen.PasswordHash);

            if (!result)
            {
                throw new Exception("Fail to login");
            }

            var token = _jwtprovider.GenerateTokenSportsmen(sportsmen);
           
            return (sportsmen,token);
        }

        public async Task<Guid> UpdateSelf(Guid id, bool isMale, DateOnly birthday,
            string address, string contacts)
        {
            return await _sportsmenRepository.UpdateSelf(id, isMale, birthday,address, contacts);
        }

        public async Task<Guid> Delete(Guid id)
        {
            return await _sportsmenRepository.Delete(id);
        }
    }
}
