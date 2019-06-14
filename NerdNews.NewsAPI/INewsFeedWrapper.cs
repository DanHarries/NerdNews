using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdNews.NewsAPI
{
    public interface INewsFeedWrapper
    {
        List<Article> GetNewsFeed();
    }
}
