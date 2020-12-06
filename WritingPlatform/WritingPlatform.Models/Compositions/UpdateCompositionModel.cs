using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Compositions
{
    public class UpdateCompositionModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
