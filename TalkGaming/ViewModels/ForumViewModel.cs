using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TalkGaming.Models;

namespace TalkGaming.ViewModels
{
    public class ForumViewModel
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public List<Posts> Posts { get; set; }
    }
}