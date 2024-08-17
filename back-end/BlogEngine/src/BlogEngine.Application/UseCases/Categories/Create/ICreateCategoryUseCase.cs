using BlogEngine.Communication.Requests.Category;
using BlogEngine.Communication.Requests.Post;
using BlogEngine.Communication.Responses.Category;
using BlogEngine.Communication.Responses.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Application.UseCases.Categories.Create;
public interface ICreateCategoryUseCase
{
    public Task<ResponseCategory> Execute(RequestCategory request);
}
