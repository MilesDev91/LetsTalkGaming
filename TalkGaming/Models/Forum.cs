using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalkGaming.Models
{
    public class Forum
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        private List<Posts> Posts;
        public List<Posts> _Posts
        {
            get
            {
                var _context = new ApplicationDbContext();
                //Get list of posts from db and assign
                var DbPosts = _context.Posts.Where(m => m.Forum_Id == this.Id).ToList();
                if (DbPosts.Count == 0)
                {
                    Posts = new List<Posts>();
                }
                else
                {
                    Posts = DbPosts;
                }
                _context.Dispose();
                return Posts;
            }
            set { Posts = value; }
        }


    }
}