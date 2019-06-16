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
            try
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

                _logger.LogInformation("Successfully got comments");
                return dto;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw new Exception();
            }
            

        }

        public bool EditComment(string id, string comment)
        {
            try
            {
                // Save comment history
                SaveCommentHistory(id);

                // Edit comment in db
                var editComment = _db.Comments.Find(Convert.ToInt32(id));
                editComment.Message = comment;
                _db.SaveChanges();
                _logger.LogInformation("Successfully edited comment");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                return false;
            }
            
        }

        public void SaveCommentHistory(string id)
        {
            try
            {
                var commentHistory = new CommentHistory()
                {
                    CommentId = id,
                    EditDateTime = DateTime.Now,
                };

                _db.CommentHistory.Add(commentHistory);
                _db.SaveChanges();
                _logger.LogInformation("Successfully saved comment history");
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Error saving comment history - {e.Message}");
                throw new Exception();
            }   

        }

        public async Task<List<CommentHistoryDTO>> GetCommentHistory(string id)
        {
            try
            {
                var commentHistoryDTO = new List<CommentHistoryDTO>();
                var getCommentHistory = await _db.CommentHistory.Where(x => x.CommentId == id).ToListAsync();

                foreach (var history in getCommentHistory)
                {
                    commentHistoryDTO.Add(new CommentHistoryDTO()
                    {
                        Id = history.Id,
                        CommentHistoryDateTime = history.EditDateTime
                    });
                }

                _logger.LogInformation($"successfully got comment history");
                return commentHistoryDTO;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error getting comment history - {e.Message}");
                throw new Exception();
            }
            

        }

        public bool DeleteComment(string id)
        {
            try
            {
                var delete = _db.Comments.Find(Convert.ToInt32(id));
                _db.Comments.Remove(delete);
                _db.SaveChanges();

                _logger.LogInformation("Successfully deleted comment");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error deleting comment - {e.Message}");
                return false;
            }
        }

        public int GetCommentCount(string id)
        {
            try
            {
                var count =  _db.Comments.Where(x => x.PostId == id).Count();
                _logger.LogInformation("Successfully got comment count");
                return count;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error getting comment count - {e.Message}");
                throw new Exception();
            }

        }
    }
}
