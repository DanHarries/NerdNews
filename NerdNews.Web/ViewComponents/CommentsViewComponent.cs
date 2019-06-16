using Microsoft.AspNetCore.Mvc;
using NerdNews.Application;
using NerdNews.Application.Models;
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

                var history = await _process.GetCommentHistory(comment.Id.ToString());

                model.Add(new CommentsViewModel()
                {
                    Id = comment.Id,
                    PostId = postId,
                    Author = comment.Author,
                    Message = comment.Message,
                    CommentDateTime = comment.CommentDateTime,
                    CommentHistory = CommentHistoryDTOToModel(history)

                });
            }

            return View(model);
        }

        public List<CommentHistoryModel> CommentHistoryDTOToModel(List<CommentHistoryDTO> dto)
        {
            var commentHistory = new List<CommentHistoryModel>();
            foreach (var item in dto)
            {
                commentHistory.Add(new CommentHistoryModel()
                {
                    CommentHistoryDateTime = item.CommentHistoryDateTime
                });
            }

            return commentHistory;
        }
    }
}
