using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NerdNews.Application;
using NerdNews.Data;
using NerdNews.Tests;
using NUnit.Framework;

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
        public void CheckCommentCount_Test()
        {     
            var postId = "test";
            int count = 2;            

            var getCount = processData.GetCommentCount(postId);

            Assert.AreEqual(count, getCount);
        }
    }
}