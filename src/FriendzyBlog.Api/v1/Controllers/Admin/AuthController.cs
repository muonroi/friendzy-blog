namespace FriendzyBlog.Api.v1.Controllers.Admin
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class AuthController(IMediator mediator) : MControllerBase(mediator)
    {
        [HttpPost("login")]
        [ProducesResponseType(typeof(MResponse<LoginResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MVoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            MResponse<LoginResponse> result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(MResponse<RegisterResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MVoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            MResponse<RegisterResponse> result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}