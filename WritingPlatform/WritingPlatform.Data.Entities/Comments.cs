﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Content { get; set; }

        [Required]
        [Column("Composition id")]
        public int CompositionId { get; set; }
    }
}
