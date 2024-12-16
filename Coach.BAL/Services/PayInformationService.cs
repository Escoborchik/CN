using Coach.Core.Interfaces;
using Coach.Core.Models;

namespace Coach.BAL.Services
{
    public class PayInformationService : IPayInformationService
    {
        private readonly IPayInformationRepository _payRepository;
        private readonly ISportsmenRepository _sportsmenRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IGroupRepository _groupRepository;



        public PayInformationService(IPayInformationRepository payRepository,
          IGroupRepository groupRepository,
          ISportsmenRepository sportsmenRepository,
          ILessonRepository lessonRepository)
        {
            _payRepository = payRepository;
            _lessonRepository = lessonRepository;
            _sportsmenRepository = sportsmenRepository;
            _groupRepository = groupRepository;


        }

        public async Task<(PayInformation, List<Payment>)> GetPaySportsmen(Guid sportsmenId, int month)
        {
            var attendance = await _sportsmenRepository.GetAttendance(sportsmenId);
            var num = attendance.attendance.Where(l => l.Date.Month == month && l.IsPresent == true).Count();
            var groupId = await _sportsmenRepository.GetGroupId(sportsmenId);
            var price = await _lessonRepository.GetPrice(groupId);
            var pay = await _payRepository.GetPaysSportsmen(sportsmenId, month);
            var sum = price * num - pay.Select(p => p.Paid).Sum(); ;
            var payment = new PayInformation(num, price, sum);


            return (payment, pay);
        }

        public async Task<List<Paymiddleware>> GetPaySportsmenForCoach(Guid groupId, int month)
        {
            var list = new List<Paymiddleware>();
            var group = await _groupRepository.GetGroup(groupId);

            foreach (var sportsmen in group.Sportsmens)
            {
                var attendance = await _sportsmenRepository.GetAttendance(sportsmen.Id);

                var attendanceMiddlewares = attendance.attendance.Where(l => l.Date.Month == month).Select(a =>
                     new AttendanceMiddleware(a.Date, a.IsPresent)).ToList();

                var num = attendance.attendance.Where(l => l.Date.Month == month && l.IsPresent == true).Count();
                var price = await _lessonRepository.GetPrice(groupId);
                var pay = await _payRepository.GetPaysSportsmen(sportsmen.Id, month);
                var sum = price * num;

                list.Add(new Paymiddleware(sportsmen.FullName, attendanceMiddlewares, pay.Sum(p => p.Paid), sum));                 
            }

            return list;
        }

        public async Task CreatePay(DateOnly date, int summary, string image, Guid sportsmenId)
        {

            var pay = new Payment(
               Guid.NewGuid(), date, summary, image, sportsmenId
            );

            await _payRepository.Create(pay);
        }



    }
}
