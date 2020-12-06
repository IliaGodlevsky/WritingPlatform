using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Mark
{
    public class NewMarkModel
    {
        public int CompositionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(0.0, 100.0)]
        public int Rating { get; set; }
    }
}
