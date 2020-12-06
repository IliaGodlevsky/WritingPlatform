using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Composition : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Column("Publication time")]
        public DateTime PublicationTime { get; set; }

        [Required]
        [Column("User id")]
        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
