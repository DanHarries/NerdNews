using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NerdNews.Web.Models
{
    public class HomePageViewModel
    {
        [Required]
        public string Comment { get; set; }
        public string NewsPostId { get; set; }
        public List<ArticleModel> ArticleModel { get; set; }
    }
}
