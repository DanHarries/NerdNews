using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NerdNews.Application;
using NerdNews.Application.Models;
using NerdNews.Data;
using NerdNews.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

       



    }
}