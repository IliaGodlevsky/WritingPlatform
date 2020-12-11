using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int CompositionId { get; set; }
    }
}
