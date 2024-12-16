using Coach.Core.Interfaces;
using Coach.Core.Models;
using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coach.DAL.Repositories
{
    public class PayInformationRepository : IPayInformationRepository
    {
        private readonly CoachLogDbContext _context;

        public PayInformationRepository(CoachLogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetPaysSportsmen(Guid sportsmenId, int month)
        {

            var payInformationEntities = await _context.PayInformations
                .Where(p => p.SportsmenId == sportsmenId && p.Date.Month == month).ToListAsync();
            var pays = payInformationEntities.Select(p => new Payment(p.Id, p.Date, p.Paid, p.Image, p.SportsmenId))
                .ToList();

            return pays;
        }
        public async Task<Payment> Create(Payment payInformation)
        {
            var sportsmen = await _context.Sportsmens.FirstOrDefaultAsync(s => s.Id == payInformation.SportsmenId);
            var paymentEntity = new PaymentEntity
            {
                Id = payInformation.Id,
                Date = payInformation.Date,
                Paid = payInformation.Paid,
                Image = payInformation.Image,
                Sportsmen = sportsmen,
                SportsmenId = payInformation.SportsmenId,

            };

            await _context.PayInformations.AddAsync(paymentEntity);
            await _context.SaveChangesAsync();

            return payInformation;
        }
    }
}
