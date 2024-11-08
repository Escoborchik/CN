using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTProvider _jwtprovider;

        public CoachService(ICoachRepository coachRepository,
            IPasswordHasher passwordHasher,
            IJWTProvider jWTProvider)
        {
            _coachRepository = coachRepository;
            _passwordHasher = passwordHasher;
            _jwtprovider = jWTProvider;
        }

        public async Task<List<CoachModel>> GetAllCoaches()
        {
            return await _coachRepository.Get();
        }

        public async Task<Guid> CreateCoach(string fullName, string email, string password)
        {
            var hashPassword = _passwordHasher.Generate(password);

            var coach = CoachModel.Create(
               Guid.NewGuid(),
               fullName,
               email,
               hashPassword, []);

            if (string.IsNullOrEmpty(coach.Error))
            {
                return await _coachRepository.Create(coach.Coach);
            }
            else
            {
                throw new Exception(coach.Error);
            }


        }

        public async Task<(string,Guid)> Login(string email, string password)
        {
            var coach = await _coachRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, coach.PasswordHash);

            if (!result)
            {
                throw new Exception("Fail to login");
            }

            var token = _jwtprovider.GenerateTokenCoach(coach);

            return (token,coach.Id);
        }

        public async Task<Guid> UpdateCoach(Guid id, string userName, string email)
        {
            return await _coachRepository.Update(id, userName, email);
        }

        public async Task<Guid> DeleteCoach(Guid id)
        {
            return await _coachRepository.Delete(id);
        }
    }
}
