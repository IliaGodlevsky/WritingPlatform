using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Comments
{
    public class UpdateCommentModel
    {
        public int Id { get; set; }

        public string Content { get; set; }       
    }
}
