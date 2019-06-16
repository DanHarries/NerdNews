using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NerdNews.Application;
using NerdNews.NewsAPI;
using NerdNews.Web.Models;
using NerdNews.Web.Services;

namespace NerdNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcessNewsFeedData _model;        
        private readonly ILogger<HomeController> _logger;
        private readonly IProcessData _process;
      
        public HomeController(IProcessNewsFeedData model, ILogger<HomeController> logger, IProcessData process)
        {            
            _model = model;
            _logger = logger;
            _process = process;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();

            _logger.LogInformation("Getting news feed data");

            var newsFeed = _model.NewsFeedToModel();
            model.ArticleModel = newsFeed;

            return View(model);
        }
           
        [HttpGet]
        public IActionResult CheckAuthorised()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { isAuth = true });
            } 
            else
            {
                return Json(new { isAuth = false });
            }
        }

        public async Task<IActionResult> AddCommment(HomePageViewModel model)
        {            
            var user = User.Identity.Name;
            _logger.LogInformation($"{user} has added a comment");

            // Save to Db
            var saveToDb = await _process.SaveCommentToDb(model.NewsPostId, model.Comment, user);

            if (saveToDb)
            {
                return RedirectToAction("Index", new {comment = "new", post = model.NewsPostId });
            }
            else
            {
                var error = new ErrorViewModel()
                {
                    ErrorMessage = "There was an issue saving your comment"
                };

                return View("Error", error);
            }

            
        }

        public IActionResult EditPost(string newEditPost, string id)
        {
            _logger.LogInformation($"{User.Identity.Name} is updating a comment");

            // Update in the DB
            var editToDb = _process.EditComment(id, newEditPost);


            return RedirectToAction("Index", "Home");
        }



      
        public IActionResult Error()
        {
            _logger.LogError("Error loading home page");

            return View(new ErrorViewModel { ErrorMessage = "Ooops Something went wrong" });
        }
    }
}
