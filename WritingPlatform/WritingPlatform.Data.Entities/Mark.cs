using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Mark : BaseEntity
    {
        [Required]
        [Column("Composition id")]
        public int CompositionId { get; set; }

        [Required]
        [Column("Mark")]
        [Range(0.0, 100.0)]
        public int Rating { get; set; }
    }
}
