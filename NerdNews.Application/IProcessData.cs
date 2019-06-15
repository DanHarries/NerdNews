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
    }
}
