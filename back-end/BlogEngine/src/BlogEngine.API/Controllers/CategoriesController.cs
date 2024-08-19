using BlogEngine.Application.UseCases.Categories.Create;
using BlogEngine.Application.UseCases.Categories.Delete;
using BlogEngine.Application.UseCases.Categories.GetAll;
using BlogEngine.Application.UseCases.Categories.GetById;
using BlogEngine.Application.UseCases.Categories.Update;
using BlogEngine.Application.UseCases.Posts.GetByCategoryId;
using BlogEngine.Communication.Requests.Category;
using BlogEngine.Communication.responses;
using BlogEngine.Communication.Responses.Category;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers;
[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(typeof(ResponseCategory), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllCategoriesUseCase useCase
        )
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseCategory), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
    [FromServices] IGetCategoryByIdUseCase useCase,
    [FromRoute] long id
    )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}/posts")]
    [ProducesResponseType(typeof(ResponseCategory), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllPostById(
    [FromServices] IGetAllPostsByCategoryIdUseCase useCase,
    [FromRoute] long id
    )
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCategory), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
    [FromServices] ICreateCategoryUseCase useCase,
    [FromBody] RequestCategory request
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
    [FromServices] IUpdateCategoryUseCase useCase,
    [FromRoute] long id,
    [FromBody] RequestCategory request
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
    [FromServices] IDeleteCategoryUseCase useCase,
    [FromRoute] long id
)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
