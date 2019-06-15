﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdNews.Web.Models
{
    public class CommentsViewModel
    {
        public string PostId { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}