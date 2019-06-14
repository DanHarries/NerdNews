using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NerdNews.NewsAPI;
using NerdNews.Web.Models;
using NerdNews.Web.Services;

namespace NerdNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcessNewsFeedData _model;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProcessNewsFeedData model, ILogger<HomeController> logger)
        {            
            _model = model;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("On Index action method getting news feed data");
            var model = _model.NewsFeedToModel();        
            
            return View(model);
        }
              

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
