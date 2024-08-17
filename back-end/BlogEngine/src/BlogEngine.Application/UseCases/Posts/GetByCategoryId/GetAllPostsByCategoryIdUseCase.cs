﻿using AutoMapper;
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

    public async Task<ResponseCreatedPosts> Execute(Guid categoryId)
    {
        var result = await _repository.GetAllByCategoryId(categoryId);

        if (result.Count == 0)
        {
            throw new NotFoundException(ResourceErrorMessages.POSTS_BY_CATEGORY_ID_NOT_FOUND);
        }

        return new ResponseCreatedPosts
        {
            Posts = _mapper.Map<List<ResponseCreatedPost>>(result)
        };
    }
}
