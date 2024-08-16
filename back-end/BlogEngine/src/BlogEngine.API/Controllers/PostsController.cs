﻿using BlogEngine.Application.UseCases.Posts;
using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedPost), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromServices] ICreatePostUseCase useCase,
        [FromBody] RequestCreatePost request
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseCreatedPost), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllPostsUseCase useCase
        )
    {
        var response = await useCase.Execute();

        if (response.Posts.Count() == 0)
            return NotFound();
        return Ok(response);
    }
}
