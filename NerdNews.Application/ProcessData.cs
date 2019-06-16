using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NerdNews.Application.Models;
using NerdNews.Data;
using NerdNews.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdNews.Application
{
    /// <summary>
    /// Process data in here to keep db calls off the controller
    /// </summary>    
    public class ProcessData : IProcessData
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ProcessData> _logger;
        public ProcessData(ApplicationDbContext db, ILogger<ProcessData> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<bool> SaveCommentToDb(string postId, string comment, string author)
        {
            try
            {
                var saveCommentData = new Comments()
                {
                    PostId = postId,
                    Author = author,
                    Message = comment,
                    CommentDateTime = DateTime.Now

                };

                await _db.AddAsync(saveCommentData);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Successfully save to db");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                return false;
            }
            
        }

        public async Task<List<CommentsDTO>> GetComments(string postId)
        {
            var dto = new List<CommentsDTO>();

            var getComments = await _db.Comments.Where(x => x.PostId == postId).ToListAsync();

            foreach (var comment in getComments)
            {
                dto.Add(new CommentsDTO()
                {
                    Id = comment.Id,
                    PostId = comment.PostId,
                    Author = comment.Author,
                    Message = comment.Message,
                    CommentDateTime = comment.CommentDateTime

                });
            }

            return dto;

        }

        public bool EditComment(string id, string comment)
        {
            try
            {
                // Edit comment in db
                var editComment = _db.Comments.Find(Convert.ToInt32(id));
                editComment.Message = comment;
                _db.SaveChangesAsync();
                _logger.LogInformation("Successfully edited comment");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                return false;
            }
            
        }
    }
}
