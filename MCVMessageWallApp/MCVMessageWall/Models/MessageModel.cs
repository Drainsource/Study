﻿using System.ComponentModel.DataAnnotations;

namespace MCVMessageWall.Models
{
    public class MessageModel
    {
        [Required]
        [StringLength(10, MinimumLength = 5)]
        [Display(Name = "Really Cool Message")]
        public string Message { get; set; }
    }
}
