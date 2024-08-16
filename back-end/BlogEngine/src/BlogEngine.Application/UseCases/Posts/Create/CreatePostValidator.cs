using BlogEngine.Communication.requests;
using FluentValidation;

namespace BlogEngine.Application.UseCases.Posts.Create;

public class CreatePostValidator : AbstractValidator<RequestCreatePost>
{
    public CreatePostValidator()
    {
        RuleFor(post => post.Title).NotEmpty().WithMessage("The title is required");
        RuleFor(post => post.PublicationDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Posts cannot be for the future");
        RuleFor(post => post.Content).NotEmpty().WithMessage("The content is required");
    }
}
