using NerdNews.Web.Models;
using NewsAPI.Models;
using System.Collections.Generic;

namespace NerdNews.Web.Services
{
    public interface IProcessNewsFeedData
    {
        List<ArticleModel> NewsFeedToModel();
    }
}