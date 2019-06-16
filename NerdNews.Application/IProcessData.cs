using NerdNews.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdNews.Application
{
    public interface IProcessData
    {
        Task<bool> SaveCommentToDb(string postId, string comment, string author);
        Task<List<CommentsDTO>> GetComments(string postId);
        bool EditComment(string postId, string comment);
        Task <List<CommentHistoryDTO>> GetCommentHistory(string id);
        bool DeleteComment(string id);
        int GetCommentCount(string id);
    }
}
