using System;
using System.Collections.Generic;
using System.Text;

namespace NerdNews.Application.Models
{
    public class CommentsDTO
    {
        public int Id { get; set; }
        public string PostId { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}
