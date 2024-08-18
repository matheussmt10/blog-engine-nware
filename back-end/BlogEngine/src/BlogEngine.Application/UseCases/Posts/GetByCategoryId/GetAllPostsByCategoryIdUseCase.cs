using AutoMapper;
using BlogEngine.Communication.Responses.Post;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception.ExceptionBase;
using BlogEngine.Exception;

namespace BlogEngine.Application.UseCases.Posts.GetByCategoryId;

public class GetAllPostsByCategoryIdUseCase : IGetAllPostsByCategoryIdUseCase
{

    private readonly IPostsRepository _repository;
    private readonly IMapper _mapper;
    public GetAllPostsByCategoryIdUseCase(
        IPostsRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponsePosts> Execute(long categoryId)
    {
        var result = await _repository.GetAllByCategoryId(categoryId);

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
