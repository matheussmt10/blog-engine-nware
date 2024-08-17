using BlogEngine.Communication.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Application.UseCases.Categories.GetAll;
internal interface IGetAllCategoriesUseCase
{
    public Task<ResponseCategories> Execute();
}
