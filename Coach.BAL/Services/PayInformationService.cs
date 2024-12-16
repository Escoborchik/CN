using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class PayInformationService : IPayInformationService
    {
        private readonly IPayInformationRepository _payRepository;        
        private readonly ISportsmenRepository _sportsmenRepository;
        private readonly ILessonRepository _lessonRepository;



        public PayInformationService(IPayInformationRepository payRepository,
          IGroupRepository groupRepository,
          ISportsmenRepository sportsmenRepository,
          ILessonRepository lessonRepository)
        {
            _payRepository = payRepository;            
            _lessonRepository = lessonRepository;
            _sportsmenRepository = sportsmenRepository;


        }

        public async Task<(PayInformation,List<Payment>)> GetPaySportsmen(Guid sportsmenId, int month)
        {
            var attendance = await _sportsmenRepository.GetAttendance(sportsmenId);
            var num = attendance.attendance.Where(l => l.Date.Month == month && l.IsPresent == true).Count();
            var groupId = await _sportsmenRepository.GetGroupId(sportsmenId);
            var price = await _lessonRepository.GetPrice(groupId);
            var sum = price * num;
            var payment = new PayInformation(num,price,sum);
            var pay = await _payRepository.GetPaysSportsmen(sportsmenId, month);

            return (payment,pay);
        }

        public async Task<Payment> CreatePay(DateOnly date, int summary, string image, Guid sportsmenId)
        {

            var pay = new Payment(
               Guid.NewGuid(), date, summary, image, sportsmenId
            );

            return await _payRepository.Create(pay);

             
        }



    }
}
