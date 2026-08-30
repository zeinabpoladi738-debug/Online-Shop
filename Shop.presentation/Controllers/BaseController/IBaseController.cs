using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.presentation.Controllers.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBaseController : ControllerBase
    {
    }
}
