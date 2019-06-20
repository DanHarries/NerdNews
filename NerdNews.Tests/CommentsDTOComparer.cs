using NerdNews.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdNews.Tests
{
    /// <summary>
    /// Custom override for Comments DTO to check two different 
    /// instances of the same object
    /// </summary>
    public class CommentsDTOComparer : IEqualityComparer<List<CommentsDTO>>
    {
        public bool Equals(List<CommentsDTO> x, List<CommentsDTO> y)
        {
            return x == y;
        }

        public int GetHashCode(List<CommentsDTO> obj)
        {
            return 1;
        }
    }
}
