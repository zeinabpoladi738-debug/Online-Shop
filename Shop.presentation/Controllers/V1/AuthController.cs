using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.User.Command;
using Shop.Application.Features.User.Query;

namespace Shop.presentation.Controllers.V1
{
    
    [ApiController]
   
    [Route("api/v{v:apiVertion}/Auth")]
    public class AuthController : ControllerBase
    {
        public readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> login([FromBody] AuthQuery authQuery)
        {
            var res = await _mediator.Send(authQuery);
            return Ok(res);
        }

        //ثبت نام و ارسال کد به شماره موبایل 
        [HttpPost("RegisterAndSendOtp")]
        public async Task<IActionResult> RegisterAndSendOtp([FromBody] AuthCommand authCommand)
        {
            var res = await _mediator.Send(authCommand);
            return Ok(res); 
        }
    }
}
