using BlogEngine.Application.UseCases.Posts;
using BlogEngine.Communication.requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICreatePostUseCase useCase,
        [FromBody] RequestPost request
        )
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
