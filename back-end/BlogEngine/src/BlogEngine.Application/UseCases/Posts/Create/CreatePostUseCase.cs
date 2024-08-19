using AutoMapper;
using BlogEngine.Application.UseCases.Categories.GetById;
using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.Responses.Post;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Posts.Create;

public class CreatePostUseCase : ICreatePostUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGetCategoryByIdUseCase _getCategoryByIdUseCase;

    public CreatePostUseCase(
        IPostsRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IGetCategoryByIdUseCase getCategoryByIdUseCase)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _getCategoryByIdUseCase = getCategoryByIdUseCase;

    }
    public async Task<ResponsePost> Execute(RequestPost request)
    {
        Validate(request);

        var postTitleAlreadyExist = await _repository.CheckIfExistByTitle(request.Title);

        if (postTitleAlreadyExist)
        {
            throw new ErrorOnValidationException([ResourceErrorMessages.TITLE_MUST_UNIQUE]);
        }
        var idCategoryExist = await _getCategoryByIdUseCase.Execute(request.CategoryId);

        if (idCategoryExist is null)
        {
            throw new NotFoundException(ResourceErrorMessages.CATEGORY_NOT_FOUND);
        }
        var post = _mapper.Map<Post>(request);

        await _repository.Add(post);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponsePost>(post);
    }

    private void Validate(RequestPost request)
    {
        var validator = new PostValidator();

        var result = validator.Validate(request);

        if (!result.IsValid) 
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
