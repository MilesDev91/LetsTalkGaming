using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalkGaming.Models
{
    public class Comment
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
        public DateTime TimeCreated { get; set; }

        public byte? Edited { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte IsEdited = 1;
    }
}