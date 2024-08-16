using AutoMapper;
using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Posts.Create;

public class CreatePostUseCase : ICreatePostUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostUseCase(
        IPostsRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }
    public async Task<ResponseCreatedPost> Execute(RequestCreatePost request)
    {
        Validate(request);

        var post = _mapper.Map<Post>(request);

        await _repository.Add(post);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCreatedPost>(post);
    }

    private void Validate(RequestCreatePost request)
    {
        var validator = new CreatePostValidator();

        var result = validator.Validate(request);

        if (!result.IsValid) 
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
