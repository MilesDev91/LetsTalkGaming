using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TalkGaming.Models
{
    public class Post
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }
        
        [Required]
        public List<Comment> Comments { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        public DateTime? LatestReply { get; set; }
    }
}