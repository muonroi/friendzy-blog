namespace FriendzyBlog.Api.v1.Applications.Command.PostCmd
{
    public class CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        : IRequestHandler<CreatePostCommand, MResponse<PostDto>>
    {
        public async Task<MResponse<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            MResponse<PostDto> result = new();
            Post postValidation = mapper.Map<Post>(request);
            if (postValidation.IsValid())
            {
                _ = postRepository.Add(postValidation);
                _ = await postRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken).ConfigureAwait(false);

                result.Result = mapper.Map<PostDto>(postValidation);
            }
            else
            {
                result.AddResultFromErrorList(postValidation.ErrorMessages);
            }
            return result;
        }
    }
}