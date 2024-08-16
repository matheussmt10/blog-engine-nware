﻿using BlogEngine.Domain.Entities;
using BlogEngine.Domain.Repositories.Posts;

namespace BlogEngine.Infrastructure.DataAccess.Repositories;

internal class PostsRepository : IPostsRepository
{
    private readonly BlogEngineDBContext _dbContext;

    public PostsRepository(BlogEngineDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Post post)
    {
      await _dbContext.Posts.AddAsync(post);
    }
}
