using System;
using System.Collections.Generic;
using System.Text;

namespace NerdNews.Data.DataModels
{
    public class Reply
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string MessageReply { get; set; }
        public string Author { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}
