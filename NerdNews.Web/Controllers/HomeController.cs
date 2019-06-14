using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NerdNews.NewsAPI;
using NerdNews.Web.Models;
using NerdNews.Web.Services;

namespace NerdNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcessNewsFeedData _model;
        

        public HomeController(IProcessNewsFeedData model)
        {
           
            _model = model;
        }

        public IActionResult Index()
        {

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
