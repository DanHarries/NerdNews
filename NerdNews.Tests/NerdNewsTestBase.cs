using Microsoft.EntityFrameworkCore;
using NerdNews.Data;
using NerdNews.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdNews.Tests
{
    public class NerdNewsTestBase : IDisposable
    {
        protected readonly ApplicationDbContext _context;
        public NerdNewsTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _context = new ApplicationDbContext(options);

            SaveCommentTestData();

            SaveCommentHistoryTestData();

        }
         public void Dispose()
         {
            _context.Database.EnsureDeleted();

            _context.Dispose();
         }

        private void SaveCommentHistoryTestData()
        {
            var addCommentHistory = new List<CommentHistory>();

            addCommentHistory.Add(
                new CommentHistory()
                {
                    Id = 1,
                    CommentId = "1",
                    EditDateTime = DateTime.Now,
                    MessageEdit = null
                });

            addCommentHistory.Add(
                new CommentHistory()
                {
                    Id = 2,
                    CommentId = "2",
                    EditDateTime = DateTime.Now.AddMinutes(10),
                    MessageEdit = null
                });


            _context.CommentHistory.AddRange(addCommentHistory);

            _context.SaveChanges();

            _context.Database.EnsureCreated();
        }

       

        public void SaveCommentTestData()
        {
            var addDate = new List<Comments>();

            addDate.Add(
                new Comments()
                {
                    Id = 1,
                    Author = "Dan",
                    CommentDateTime = Convert.ToDateTime("10/9/2019 9:45:06 PM"),
                    Message = "Test 1",
                    PostId = "test"
                });

            addDate.Add(
                new Comments()
                {
                    Id = 2,
                    Author = "Dan 2",
                    CommentDateTime = Convert.ToDateTime("10/9/2019 9:57:06 PM"),
                    Message = "Test 2",
                    PostId = "test"
                });


            _context.Comments.AddRange(addDate);

            _context.SaveChanges();

            _context.Database.EnsureCreated();

        }


    }
}
