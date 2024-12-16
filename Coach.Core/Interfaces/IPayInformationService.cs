using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IPayInformationService
    {
        Task<Payment> CreatePay(DateOnly date, int summary, string image, Guid sportsmenId);
        Task<(PayInformation, List<Payment>)> GetPaySportsmen(Guid sportsmenId,int month);
    }
}