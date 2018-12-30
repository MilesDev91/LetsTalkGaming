using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TalkGaming.Models;

namespace TalkGaming.ViewModels
{
    public class PostViewModel
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }

        [Required]
        public List<Comments> Comments { get; set; }
    }
}