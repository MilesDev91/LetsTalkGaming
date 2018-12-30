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

        public int Forum_Id { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }

        public PostFormViewModel()
        {
            Id = 0;
        }

        public PostFormViewModel(Posts post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
            Forum_Id = post.Forum_Id;
        }
    }
}