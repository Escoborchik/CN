using Coach.Core.Models;

namespace Coach.Core.Interfaces
{
    public interface IPayInformationRepository
    {
        Task<Payment> Create(Payment payInformation);
        Task<List<Payment>> GetPaysSportsmen(Guid sportsmenId,int month);
    }
}