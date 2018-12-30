using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
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

        [Route("Posts/ViewPostDetails/{id}")]
        public ActionResult ViewPostDetails(int id)
        {
            var post = _context.Posts.Single(m => m.Id == id);
            if (post == null)
                return HttpNotFound();
            var viewModel = new PostViewModel
            {
                Title = post.Title,
                Id = id,
                Content = post.Content,
                Comments = post._Comments
            };

            return View("ViewPostDetails", viewModel);
        }

        

        public ActionResult NewPost(string param1)
        {
            var forumTitle = param1;
            var forumId = _context.Forums.Single(m => m.Title == forumTitle).Id;
            var viewModel = new PostFormViewModel {
                ForumName = forumTitle
            };
            viewModel.Forum_Id = forumId;

            return View("NewPost", viewModel);
        }

        public ActionResult SavePost(Posts post)
        {
            var forumTitle = _context.Forums.Single(m => m.Id == post.Forum_Id).Title;
            _context.Posts.Attach(post);
            if (!ModelState.IsValid)
            {
                var viewModel = new PostFormViewModel(post)
                {
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

        public ActionResult NewComment(int postId)
        {
            var viewModel = new CommentFormViewModel
            {
                PostId = postId,
                Comment = new Comments()
            };
            return View("NewComment", viewModel);
        }

        public ActionResult SaveComment(Comments comment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CommentFormViewModel
                {
                    Comment = comment,
                    PostId = comment.Post_Id
                };
                return View("NewComment", viewModel);
            }
            Posts post = _context.Posts.SingleOrDefault(m => m.Id == comment.Post_Id);
            // Checks if comment is new and adds if so
            if (comment.Id == 0)
            {
                comment.TimeCreated = DateTime.Now;
                post._Comments.Add(comment);
                _context.Comments.Add(comment);
            }
            // Else edits
            else
            {
                var commentInDb = _context.Comments.Single(m => m.Id == comment.Id);
                commentInDb.Content = comment.Content;
            }

            _context.SaveChanges();

            // Redirects to post
            var postViewModel = new PostViewModel
            {
                Title = post.Title,
                Id = post.Id,
                Content = post.Content,
                Comments = post._Comments
            };
            return View("ViewPostDetails", postViewModel);
        }
    }
}