using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace TalkGaming.Models
{
    public class Posts
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }

        private List<Comments> Comments { get; set; }
        public List<Comments> _Comments
        {
            get
            {
                var _context = new ApplicationDbContext();
                //Get list of comments from db and assign
                var DbComments = _context.Comments.Where(m => m.Post_Id == this.Id).ToList();
                if (DbComments.Count == 0)
                {
                    Comments = new List<Comments>();
                }
                else
                {
                    Comments = DbComments;
                }
                _context.Dispose();
                return Comments;
            }
            set { Comments = value; }
        }

        [Required]
        public DateTime TimeCreated { get; set; }

        public DateTime? LatestReply { get; set; }

        [Display(Name = "Forum")]
        public int Forum_Id { get; set; }

        [ForeignKey("Forum_Id")]
        public virtual Forum Forums { get; set; }
    }
}