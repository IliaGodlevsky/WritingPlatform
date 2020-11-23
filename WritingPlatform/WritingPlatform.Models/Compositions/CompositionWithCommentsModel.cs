using System.Collections.Generic;
using WritingPlatform.Models.Comments;

namespace WritingPlatform.Models.Compositions
{
    public class CompositionWithCommentsModel : CompositionModel
    {
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}