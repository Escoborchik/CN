using Coach.Core.Interfaces;
using Coach_s_Log.DTO.PayDTO;
using Microsoft.AspNetCore.Mvc;

namespace Coach_s_Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayInformationService _payService;

        public PayController(IPayInformationService payService)
        {
            _payService = payService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PayInformationResponse>> GetPaysSportsmen(PaymentSportsmenRequest request)
        {
            var pays = await _payService.GetPaySportsmen(request.SportsmenId,request.Month);
            var payResponses = pays.Item2.Select(p => new PayResponse(p.Date,p.Paid,p.Image)).ToList();
            var stat = pays.Item1;
            var ans = new PayInformationResponse(payResponses, stat.Summary, stat.NumberTrain, stat.Price);
            return Ok(ans);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<PayInformationResponse>> CreatePay([FromBody] PayRequest pay)
        {
            await _payService.CreatePay(pay.Date, pay.Summary, pay.Image, pay.Sportsmen);

            return await GetPaysSportsmen(new PaymentSportsmenRequest(pay.Sportsmen,pay.Date.Month));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PayInformationCoachResponse>> GetPaysForCoach(PayInformationCoachRequest request)
        {
            var list = await _payService.GetPaySportsmenForCoach(request.GroupId, request.Month);

            return new PayInformationCoachResponse(list);
        }
    }
}
