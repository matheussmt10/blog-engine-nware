using AutoMapper;
using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.responses;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Posts;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Posts.Update;

public class UpdatePostUseCase : IUpdatePostUseCase
{
    private readonly IPostsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdatePostUseCase(IUnitOfWork unitOfWork, IMapper mapper, IPostsRepository repository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = repository;
    }
    public async Task Execute(Guid id, RequestCreatePost request)
    {
        Validate(request);
        var post = await _repository.GetById(id);
        if (post is null) 
        {
            throw new NotFoundException(ResourceErrorMessages.POST_NOT_FOUND);
        }
        _mapper.Map(request, post);

        _repository.Update(post);

        await _unitOfWork.Commit();

    }

    private void Validate(RequestCreatePost request)
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
