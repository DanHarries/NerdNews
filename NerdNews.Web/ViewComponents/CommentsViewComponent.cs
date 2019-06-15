using Microsoft.AspNetCore.Mvc;
using NerdNews.Application;
using NerdNews.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdNews.Web.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly IProcessData _process;
        public CommentsViewComponent(IProcessData process)
        {
            _process = process;
        }
        public async Task<IViewComponentResult> InvokeAsync(string postId)
        {
            
            var getComments = await _process.GetComments(postId);
            var model = new List<CommentsViewModel>();

            foreach (var comment in getComments)
            {
                model.Add(new CommentsViewModel()
                { 
                    PostId = postId,
                    Author = comment.Author,
                    Message = comment.Message,
                    CommentDateTime = comment.CommentDateTime
                });
            }

            return View(model);
        }
    }
}
