using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace NerdNews.NewsAPI
{
    /// <summary>
    /// Wrapper class for NewsAPI - https://newsapi.org/
    /// </summary>
    public class NewsFeedWrapper : INewsFeedWrapper
    {
        private readonly ILogger<NewsFeedWrapper> _logger;

        /// <summary>
        /// Returns a list of Top Technology headlines
        /// </summary>
        /// <returns></returns>
        /// 
        public NewsFeedWrapper(ILogger<NewsFeedWrapper> logger)
        {
            _logger = logger;
        }

        public List<Article> GetNewsFeed()
        {
            var apiKey = ConfigurationManager.AppSettings["newsAPIKey"];            
            var newsApiClient = new NewsApiClient(apiKey);

            try
            {
                _logger.LogInformation("Getting news feed from api");
                var articlesResponse = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest
                {
                    PageSize = 10,
                    Q = "Technology",
                    Language = Languages.EN,
                });

                if (articlesResponse.Status == Statuses.Ok)
                {
                    _logger.LogInformation("Status Ok, returning model");
                    return articlesResponse.Articles;
                }
                else
                {
                    throw new Exception();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError($"Error getting news feed {ex.Message}");
                throw ex.InnerException;
            }


        }
    }
}
