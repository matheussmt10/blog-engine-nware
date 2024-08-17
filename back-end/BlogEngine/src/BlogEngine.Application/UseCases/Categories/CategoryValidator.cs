using BlogEngine.Communication.Requests.Category;
using BlogEngine.Domain.Entities;
using BlogEngine.Exception;
using FluentValidation;

namespace BlogEngine.Application.UseCases.Categories;

public class CategoryValidator : AbstractValidator<RequestCategory>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
    }
}
