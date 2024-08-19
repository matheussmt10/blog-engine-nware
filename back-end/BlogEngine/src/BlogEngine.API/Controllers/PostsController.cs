using BlogEngine.Application.UseCases.Posts.Create;
using BlogEngine.Application.UseCases.Posts.Delete;
using BlogEngine.Application.UseCases.Posts.GetAll;
using BlogEngine.Application.UseCases.Posts.GetById;
using BlogEngine.Application.UseCases.Posts.Update;
using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.responses;
using BlogEngine.Communication.Responses.Post;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers;
[Route("[controller]")]
[ApiController]
public class PostsController : ControllerBase
{


    [HttpGet]
    [ProducesResponseType(typeof(ResponsePost), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllPostsUseCase useCase
        )
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePost), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
    [FromServices] IGetPostByIdUseCase useCase,
    [FromRoute] long id
    )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponsePost), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
    [FromServices] ICreatePostUseCase useCase,
    [FromBody] RequestPost request
    )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
    [FromServices] IUpdatePostUseCase useCase,
    [FromRoute] long id,
    [FromBody] RequestPost request
)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
    [FromServices] IDeletePostUseCase useCase,
    [FromRoute] long id
)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
