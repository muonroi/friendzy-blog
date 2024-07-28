namespace FriendzyBlog.Api.v1.Controllers.Admin
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostController(IMediator mediator, IPostQueries postQueries, IMapper mapper) : MControllerBase(mediator)
    {
        [HttpPost]
        [ProducesResponseType(typeof(MResponse<PostDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(MVoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand request)
        {
            MResponse<PostDto> result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            MResponse<PostDto> result = new();
            Post? post = await postQueries.GetByGuidAsync(id).ConfigureAwait(false);
            if (post == null)
            {
                result.AddApiErrorMessage(StatusCodes.Status404NotFound.ToString(), ["Post not found"]);
                return NotFound(result);
            }
            result.Result = mapper.Map<PostDto>(post);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPostsPaging(string? keyword, Guid? categoryId,
            int pageIndex = 1, int pageSize = 10)
        {
            MResponse<MPagedResult<PostInListDto>> result = await postQueries.GetPostPaging(keyword, categoryId, pageIndex, pageSize).ConfigureAwait(false);
            if (result.Result == null)
            {
                result.AddApiErrorMessage(StatusCodes.Status404NotFound.ToString(), ["Post not found"]);
            }
            return Ok(result);
        }
    }
}