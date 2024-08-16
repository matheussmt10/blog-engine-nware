using AutoMapper;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Application.UseCases.Posts;

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
    public async Task<ResponseCreatedPosts> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseCreatedPosts
        {
            Posts = _mapper.Map<List<ResponseCreatedPost>>(result)
        };
    }
}
