using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IJWTProvider
    {
        string GenerateTokenCoach(CoachModel coach);
        string GenerateTokenSportsmen(Sportsmen sportsmen);
    }
}