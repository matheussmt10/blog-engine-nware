using BlogEngine.Communication.requests;
using BlogEngine.Exception;
using FluentValidation;

namespace BlogEngine.Application.UseCases.Posts.Create;

public class CreatePostValidator : AbstractValidator<RequestCreatePost>
{
    public CreatePostValidator()
    {
        RuleFor(post => post.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(post => post.PublicationDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.POSTS_CANNOT_FOR_THE_FUTURE);
        RuleFor(post => post.Content).NotEmpty().WithMessage(ResourceErrorMessages.CONTENT_REQUIRED);
    }
}
