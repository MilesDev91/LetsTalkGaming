using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TalkGaming.Models;

namespace TalkGaming.ViewModels
{
    public class PostFormViewModel
    {
        [Required]
        [StringLength(255)]
        public string ForumName { get; set; }

        [Required]
        public Posts Post { get; set; }
    }
}