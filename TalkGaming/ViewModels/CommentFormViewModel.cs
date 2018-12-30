using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TalkGaming.Models;

namespace TalkGaming.ViewModels
{
    public class CommentFormViewModel
    {
        [Required]
        public Comments Comment { get; set; }
        
        [Required]
        public int PostId { get; set; }
    }
}