﻿using AutoMapper;
using BlogEngine.Application.UseCases.Posts;
using BlogEngine.Communication.Requests.Category;
using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.Responses.Category;
using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories;
using BlogEngine.Domain.Repositories.Categories;
using BlogEngine.Exception;
using BlogEngine.Exception.ExceptionBase;

namespace BlogEngine.Application.UseCases.Categories.Create;

public class CreateCategoryUseCase : ICreateCategoryUseCase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryUseCase(ICategoryRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseCategory> Execute(RequestCategory request)
    {
        Validate(request);

        var categoryTitleAlreadyExist = await _repository.CheckIfExistByTitle(request.Title);

        if (categoryTitleAlreadyExist)
        {
            throw new ErrorOnValidationException([ResourceErrorMessages.TITLE_MUST_UNIQUE]);
        }
        var category = _mapper.Map<Category>(request);

        await _repository.Add(category);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCategory>(category);

    }

    private void Validate(RequestCategory request)
    {
        var validator = new CategoryValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
