using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Comments
{
    public class UpdateCommentModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }       
    }
}
