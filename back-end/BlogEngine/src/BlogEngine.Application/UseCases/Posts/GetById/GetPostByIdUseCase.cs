using AutoMapper;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Application.UseCases.Posts.GetById;

public class GetPostByIdUseCase : IGetPostByIdUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IMapper _mapper;
    public GetPostByIdUseCase(
        IPostsRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseCreatedPost> Execute(Guid id)
    {
        var result = await _repository.GetById(id);

        return _mapper.Map<ResponseCreatedPost>(result);
    }
}
