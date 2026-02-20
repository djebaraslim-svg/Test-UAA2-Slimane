using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.Presentation.WebAPI.Dto.Request;

namespace Starter_CleanArch_UAA2.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public IActionResult Subscribe([FromBody] SubscribeRequestDto request)
        {
            _subscriptionService.Subscribe(request.Email, request.Nouveautes, request.RecapitulatifMois, request.FaitDuJour);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Unsubscribe([FromBody] UnsubscribeRequestDto request)
        {
            _subscriptionService.Unsubscribe(request.Email);
            return Ok();
        }





    }
}
