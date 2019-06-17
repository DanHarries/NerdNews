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

            var addDate = new List<Comments>();

            addDate.Add(
                new Comments()
                {
                    Id = 1,
                    Author = "Dan",
                    CommentDateTime = DateTime.Now,
                    Message = "Test 1",
                    PostId = "test"
                });

            addDate.Add(
                new Comments()
                {
                    Id = 2,
                    Author = "Dan 2",
                    CommentDateTime = DateTime.Now.AddMinutes(10),
                    Message = "Test 2",
                    PostId = "test"
                });


            _context.Comments.AddRange(addDate);

            _context.SaveChanges();

            _context.Database.EnsureCreated();
            

        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }

        
    }
}
