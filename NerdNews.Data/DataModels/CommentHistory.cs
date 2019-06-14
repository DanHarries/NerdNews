using System;
using System.Collections.Generic;
using System.Text;

namespace NerdNews.Data.DataModels
{
    public class CommentHistory
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string MessageEdit { get; set; }
        public DateTime EditDateTime { get; set; }
    }
}
