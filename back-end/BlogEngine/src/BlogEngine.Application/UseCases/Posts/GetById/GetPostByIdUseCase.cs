using AutoMapper;
using BlogEngine.Communication.Responses.Post;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

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

        if (result is null) 
        {
            throw new NotFoundException(ResourceErrorMessages.POST_NOT_FOUND);
        }

        return _mapper.Map<ResponseCreatedPost>(result);
    }
}
