using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdNews.NewsAPI
{
    /// <summary>
    /// Wrapper class for NewsAPI - https://newsapi.org/
    /// </summary>
    public class NewsFeedWrapper : INewsFeedWrapper
    {
        /// <summary>
        /// Returns a list of Top Technology headlines
        /// </summary>
        /// <returns></returns>
        public List<Article> GetNewsFeed()
        {
            //TODO: put in config
            var newsApiClient = new NewsApiClient("2b20c702e5734ccfac06de9fcd050cad");

            try
            {
                var articlesResponse = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest
                {
                    PageSize = 10,
                    Q = "Technology",
                    Language = Languages.EN,
                });

                return articlesResponse.Articles;

            }
            catch (Exception ex)
            {
                //TODO: Log the error 
                throw;
            }
                       

        }
    }
}
