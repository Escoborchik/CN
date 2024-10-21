using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IJWTProvider
    {
        string GenerateToken(CoachModel coach);
    }
}