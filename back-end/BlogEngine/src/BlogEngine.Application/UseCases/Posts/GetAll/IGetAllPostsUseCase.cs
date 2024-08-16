using BlogEngine.Communication.requests;
using BlogEngine.Communication.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Application.UseCases.Posts.GetAll;
public interface IGetAllPostsUseCase
{
    public Task<ResponseCreatedPosts> Execute();
}
