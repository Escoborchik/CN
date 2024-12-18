using Coach.Core.Interfaces;
using Coach_s_Log.DTO.PayDTO;
using MangaMania.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coach_s_Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayInformationService _payService;
        private readonly IFileService _fileService;

        public PayController(IPayInformationService payService, IFileService fileService)
        {
            _payService = payService;
            _fileService = fileService;
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
        public async Task<ActionResult<PayInformationResponse>> AddPay([FromForm] PayImageRequest pay)
        {
            var path = "";
            if (pay.ImageFile != null)
            {

                var img = pay.ImageFile;

                try
                {
                    var savedFilePath = _fileService.SaveImage(img);
                    path = savedFilePath;
                }
                catch (Exception)
                {
                    return Problem($"there is an error while saving file {img.FileName}");
                }

            }
            DateOnly date = DateOnly.Parse(pay.Date);

            await _payService.CreatePay(date, pay.Summary, path, pay.Sportsmen);

            return await GetPaysSportsmen(new PaymentSportsmenRequest(pay.Sportsmen, date.Month));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PayInformationCoachResponse>> GetPaysForCoach(PayInformationCoachRequest request)
        {
            var list = await _payService.GetPaySportsmenForCoach(request.GroupId, request.Month);

            return new PayInformationCoachResponse(list);
        }
    }
}
