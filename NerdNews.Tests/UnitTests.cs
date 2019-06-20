using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NerdNews.Application;
using NerdNews.Application.Models;
using NerdNews.Data;
using NerdNews.Data.DataModels;
using NerdNews.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    public class Tests : NerdNewsTestBase
    {
        private ProcessData processData;
        private Logger<ProcessData> logger;

        [SetUp]
        public void Setup()
        {
            logger = new Logger<ProcessData>(new NullLoggerFactory());
            processData = new ProcessData(_context, logger);            
            
        }

        [Test]
        [TestCase("test")]
        public void CheckCommentCount_Test(string postId)
        {     
            int count = 2;       

            var getCount = processData.GetCommentCount(postId);

            Assert.AreEqual(count, getCount);
            
                
        }


        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public void DeleteComment_Test(string id)
        {
            var delete = processData.DeleteComment(id);

            Assert.IsTrue(delete);
          
        }

        [TestCase("test")]
        public async Task GetComments_Test(string postId)
        {
            // Custom override for different instances
            var commentsComparer = new CommentsDTOComparer();

            // Add comparable data
            var comments = new List<CommentsDTO>
            {
                new CommentsDTO()
                {
                    Id = 1,
                    Author = "Dan",
                    CommentDateTime = Convert.ToDateTime("10/9/2019 9:45:06 PM"),
                    Message = "Test 1",
                    PostId = "test"
                },
                new CommentsDTO()
                {
                    Id = 2,
                    Author = "Dan 2",
                    CommentDateTime = Convert.ToDateTime("10/9/2019 9:57:06 PM"),
                    Message = "Test 2",
                    PostId = "test"
                }
            };

            var commentData = await processData.GetComments(postId);

            // Assert ... 
            commentsComparer.Equals(comments, commentData);


        }



    }

}