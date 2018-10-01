using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalkGaming.Models;
using TalkGaming.ViewModels;

namespace TalkGaming.Controllers
{
    public class ForumsController : Controller
    {
        private ApplicationDbContext _context;

        public ForumsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get all Forums
        public ActionResult Index()
        {
            return View("List");
        }

        // Get specific forum view
        public ActionResult Forum(int id)
        {
            var forum = _context.Forums.Single(f => f.Id == id);

            var title = forum.Title;
            
            var posts = forum._Posts;

            var viewModel = new ForumViewModel
            {
                Title = title,
                Posts = posts
            };

            return View("Forum", viewModel);
        }
    }
}