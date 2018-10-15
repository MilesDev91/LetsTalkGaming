using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalkGaming.Models;
using TalkGaming.ViewModels;

namespace TalkGaming.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        [Route("Posts/ViewPost/{id}")]
        public ActionResult ViewPost(int id)
        {
            var post = _context.Posts.Single(m => m.Id == id);
            if (post == null)
                return HttpNotFound();

            return View("ViewPost", post);
        }

        public ActionResult NewPost(string param1)
        {
            var forumTitle = param1;
            var forumId = _context.Forums.Single(m => m.Title == forumTitle).Id;
            var viewModel = new PostFormViewModel {
                ForumName = forumTitle,
                Post = new Posts()
            };
            viewModel.Post.Forum_Id = forumId;

            return View("NewPost", viewModel);
        }

        public ActionResult Save(Posts post)
        {
            var forumTitle = _context.Forums.Single(m => m.Id == post.Forum_Id).Title;
            if (!ModelState.IsValid)
            {
                var viewModel = new PostFormViewModel
                {
                    Post = post,
                    ForumName = forumTitle
                };

                return View("NewPost", viewModel);
            }
            Forum forum = _context.Forums.SingleOrDefault(m => m.Id == post.Forum_Id);
            //Checks if post is new, and adds it if so
            if (post.Id == 0)
            {
                post.TimeCreated = DateTime.Now;
                forum._Posts.Add(post);
                _context.Posts.Add(post);
            }
            else
            {
                var postInDb = _context.Posts.Single(m => m.Id == post.Id);

                postInDb.Title = post.Title;
                postInDb.Content = post.Content;
            }
            _context.SaveChanges();

            //Redirect to specific forum with its viewmodel
            var forumViewModel = new ForumViewModel
            {
                Title = forumTitle,
                Posts = forum._Posts
            };

            return View("Forum", forumViewModel);
            

        }
    }
}