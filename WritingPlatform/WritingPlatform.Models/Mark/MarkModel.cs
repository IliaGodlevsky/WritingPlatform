using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Mark
{
    public class MarkModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CompositionId { get; set; }

        [Required]
        [Range(0.0, 100.0)]
        public int Rating { get; set; }
    }
}
