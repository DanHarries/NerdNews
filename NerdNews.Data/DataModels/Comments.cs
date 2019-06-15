﻿using System;

namespace NerdNews.Data.DataModels
{
    public class Comments
    {
        public int Id { get; set; }
        public string PostId { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}