using AutoMapper;
using BlogEngine.Communication.Responses.Post;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Posts.GetAll;

public class GetAllPostsUseCase : IGetAllPostsUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IMapper _mapper;
    public GetAllPostsUseCase(
        IPostsRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponsePosts> Execute()
    {
        var result = await _repository.GetAll();

        if (result.Count == 0)
        {
            throw new NoContentException(string.Empty);
        }

        return new ResponsePosts
        {
            Posts = _mapper.Map<List<ResponsePost>>(result)
        };
    }
}
