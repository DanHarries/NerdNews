using NerdNews.NewsAPI;
using NerdNews.Web.Models;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdNews.Web.Services
{
    /// <summary>
    /// Class to process API data and keep data calls off the controller
    /// </summary>
    public class ProcessNewsFeedData : IProcessNewsFeedData
    {
        private readonly INewsFeedWrapper _news;
        public ProcessNewsFeedData(INewsFeedWrapper news)
        {
            _news = news;
        }
        /// <summary>
        /// DTO method from API to view model
        /// </summary>
        /// <returns></returns>
        public List<ArticleModel> NewsFeedToModel()
        {
            var articles = _news.GetNewsFeed();
            var vm = new List<ArticleModel>();            

            foreach (var article in articles)
            {
                // Having to use time as an id due to the API not supplying any type of UID
                var id = article.PublishedAt.Value.TimeOfDay.ToString().Substring(0, 5).Trim().Replace(':', '-');

                vm.Add(new ArticleModel
                {                         
                    Id = id,
                    Name = article.Source.Name,
                    Author = article.Author,
                    Description = article.Description,
                    PublishedAt = article.PublishedAt,
                    Title = article.Title,
                    Url = article.Url,
                    UrlToImage = article.UrlToImage
                });
            }

            return vm;
        }
    }
}
