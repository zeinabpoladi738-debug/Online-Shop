using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.User.Command;
using Shop.presentation.Controllers.BaseController;

namespace Shop.presentation.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : IBaseController
    {
        public readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        public async Task<IActionResult> Insert([FromBody] UserCommand userCommand)
        {
            var res = await _mediator.Send(userCommand);
            return Ok(res); 
        }
    }
}
