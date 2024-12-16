using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IPayInformationService
    {
        Task CreatePay(DateOnly date, int summary, string image, Guid sportsmenId);
        Task<(PayInformation, List<Payment>)> GetPaySportsmen(Guid sportsmenId,int month);
        Task<List<Paymiddleware>> GetPaySportsmenForCoach(Guid groupId, int month);
    }
}